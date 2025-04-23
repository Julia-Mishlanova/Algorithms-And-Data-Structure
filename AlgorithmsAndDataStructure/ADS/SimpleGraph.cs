using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_ADS
{
   public class Vertex
    {
        public int Value;
        public bool Hit;

        public Vertex(int val)
        {
            Value = val;
            Hit = false;
        }
    }

    public class SimpleGraph
    {
        public Vertex[] vertex;
        public int[,] m_adjacency;
        public int max_vertex;

        public SimpleGraph(int size)
        {
            max_vertex = size;
            m_adjacency = new int[size, size];
            vertex = new Vertex[size];
        }
        public List<Vertex> DepthFirstSearch(int VFrom, int VTo)
        {
            foreach (var v in vertex)
                v.Hit = false;

            List<Vertex> route = new List<Vertex>();
            Stack<Vertex> stack = new Stack<Vertex>();

            var VertexFrom = vertex.ElementAt(VFrom);
            var VertexTo = vertex.ElementAt(VTo);

            VertexFrom.Hit = true;
            stack.Push(VertexFrom);

            while (stack.Count > 0)
            {
                var currentVertex = stack.Pop();
                route.Add(currentVertex);

                if (currentVertex.Value == VertexTo.Value)
                {
                    return route;
                }
                var vertexNeighbors = GetVertexNeighbors(currentVertex)
                    .OrderByDescending(u => u.Value)
                    .ToList();

                vertexNeighbors.ForEach(v => stack.Push(v));
            }

            return route;
        }
        private List<Vertex> GetVertexNeighbors(Vertex v)
        {
            List<Vertex> neighbors = new List<Vertex>();
            int vertexIndex = Array.IndexOf(vertex, v);

            for (int i = 0; i < vertex.Length; i++)
            {
                if (IsEdge(vertexIndex, i) && vertex[i].Hit == false)
                {
                    neighbors.Add(vertex[i]);
                    vertex[i].Hit = true;
                }
            }
            return neighbors;
        }
        public List<Vertex> BreadthFirstSearch(int VFrom, int VTo)
        {
            Dictionary<Vertex, Vertex> routes = new Dictionary<Vertex, Vertex>();
            Queue<Vertex> queue = new Queue<Vertex>();

            foreach (var item in vertex) item.Hit = false;
            queue.Clear();

            var vertexFrom = vertex.ElementAt(VFrom);
            var vertexTo = vertex.ElementAt(VTo);

            vertexFrom.Hit = true;
            queue.Enqueue(vertexFrom);
            routes.Add(vertexFrom, vertexFrom);

            while (queue.Count > 0)
            {
                var currentVertex = queue.Dequeue();

                var vertexNeighbors = GetVertexNeighbors(currentVertex)
                    .OrderBy(u => u.Value)
                    .ToList();

                foreach (var item in vertexNeighbors)
                {
                    queue.Enqueue(item);
                    routes.Add(item, currentVertex);
                }
            }

            return GetOptimalRoute(routes, vertexTo, vertexFrom);
        }

        private List<Vertex> GetOptimalRoute(Dictionary<Vertex, Vertex> routes, Vertex vertexTo, Vertex vertexFrom)
        {
            List<Vertex> route = new List<Vertex>();
            Vertex current = vertexTo;
            while (current != vertexFrom)
            {
                if (!routes.ContainsKey(current)) return new List<Vertex>();
                {
                    route.Add(current);
                    current = routes[current];
                }
            }

            route.Add(vertexFrom);
            return route;
        }

        public void AddVertex(int value)
        {
            for (int i = 0; i < max_vertex; i++)
            {
                if (vertex[i] == null)
                {
                    vertex[i] = new Vertex(value);
                    break;
                }
            }
        }

        // Здесь и далее, параметры v - индекс вершины в списке
        public void RemoveVertex(int v)
        {
            vertex[v] = null;

            for (int i = 0; i < max_vertex; i++)
            {
                m_adjacency[v, i] = 0;
                m_adjacency[i, v] = 0;
            }
        }

        public bool IsEdge(int v1, int v2)
        {
            if (m_adjacency[v1, v2] == 1 && m_adjacency[v2, v1] == 1)
            {
                return true;
            }
            return false;
        }

        public void AddEdge(int v1, int v2)
        {
            m_adjacency[v1, v2] = 1;
            m_adjacency[v2, v1] = 1;
        }

        public void RemoveEdge(int v1, int v2)
        {
            m_adjacency[v1, v2] = 0;
            m_adjacency[v2, v1] = 0;
        }

        public List<Vertex> WeakVertices()
        {
            List<Vertex> vertices = new List<Vertex>();

            foreach (var v in vertex)
            {
                if (CheckEdges(v) == false) vertices.Add(v);
            }
            return vertices;
        }
        private bool CheckEdges(Vertex v)
        {
            List<Vertex> edges = new List<Vertex>();

            for (int i = 0; i < vertex.Length; i++)
            {
                if (IsEdge(v.Value, vertex[i].Value))
                {
                    edges.Add(vertex[i]);
                }
            }

            for (int i = 0; i < edges.Count; i++)
            {
                for (int j = 0; j < edges.Count; j++)
                {
                    if (IsEdge(edges[i].Value, edges[j].Value))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

    }
}
