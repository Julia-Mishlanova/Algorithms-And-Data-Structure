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
        public bool Hit;
        public int Value;
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

        public void AddVertex(int value)
        {

            int i = 0;
            bool hasPlace = false;

            while (i < max_vertex)
            {
                if (vertex[i] == null)
                {
                    hasPlace = true;
                    break;
                }
                i++;
            }
            if (hasPlace)
            {
                vertex[i] = new Vertex(value);
            }
        }

        // v - индекс вершины в массиве vertex
        public void RemoveVertex(int v)
        {
            vertex = GetNewVertex(v);
            m_adjacency = GetNewAdjacency(v);

            max_vertex--;
        }

        private int[,] GetNewAdjacency(int v)
        {
            var adjacency = new int[max_vertex - 1, max_vertex - 1];

            for (int i = 0, g = 0; i < max_vertex && g < max_vertex - 1; i++)
            {
                if (i != v)
                {
                    for (int j = 0, q = 0; j < max_vertex && q < max_vertex - 1; j++)
                    {
                        if (j != v)
                        {
                            adjacency[g, q] = m_adjacency[i, j];
                            q++;
                        }
                    }
                    g++;
                }
            }

            return adjacency;
        }

        private Vertex[] GetNewVertex(int v)
        {
            var newVertex = new Vertex[max_vertex - 1];

            for (int i = 0, j = 0; i < max_vertex && j < max_vertex - 1; i++)
            {
                if (i != v)
                {
                    if (vertex[i] == null) return null;

                    var value = vertex[i].Value;
                    newVertex[j] = new Vertex(value);
                    j++;
                }
            }

            return newVertex;
        }

        public bool IsEdge(int v1, int v2)
        {

            var indV1 = IndexOf(v1);
            var indV2 = IndexOf(v2);

            if (indV1 == -1 || indV2 == -1) return false; 

            if (m_adjacency[indV1, indV2] == 1 || m_adjacency[indV2, indV1] == 1)
            {
                return true;
            }

            return false;
        }

        public void AddEdge(int v1, int v2)
        {

            var indV1 = IndexOf(v1);
            var indV2 = IndexOf(v2);

            if (indV1 == -1 || indV2 == -1) return; 

            m_adjacency[indV1, indV2] = 1;
            m_adjacency[indV2, indV1] = 1;
        }

        private int IndexOf(int v1)
        {
            for (int i = 0; i < max_vertex; i++)
            {
                if (vertex[i] == null) continue;

                if (Equals(vertex[i].Value, v1))
                {
                    return i;
                }
            }
            return -1;
        }
        public void RemoveEdge(int v1, int v2)
        {
            var indV1 = IndexOf(v1);
            var indV2 = IndexOf(v2);

            if (indV1 == -1 || indV2 == -1) return;

            m_adjacency[indV1, indV2] = 0;
            m_adjacency[indV2, indV1] = 0;
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
                var vertexNeighbors = GetVertexNeighbors(currentVertex.Value)
                    .OrderByDescending(u => u.Value)
                    .ToList();

                vertexNeighbors.ForEach(v => stack.Push(v));
            }

            return route;
        }
        public List<Vertex> GetVertexNeighbors(int vertexIndex)
        {
            List<Vertex> neighbors = new List<Vertex>();
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
            List<Vertex> path = new List<Vertex>();
            System.Collections.Generic.Queue<Vertex> queue = new System.Collections.Generic.Queue<Vertex>();

            int i = IndexOf(VFrom);
            if (i == -1) return path;

            int j = IndexOf(VTo);
            if (j == -1) return path;

            vertex[i].Hit = true;
            queue.Enqueue(vertex[i]);

            StartBreadthFirstSearch(VTo, ref queue, ref path);
            
            return path.Last().Value == VTo ? path : null;
        }
        private void StartBreadthFirstSearch(int VTo, ref System.Collections.Generic.Queue<Vertex> queue, ref List<Vertex> path)
        {
            if (queue.Count == 0) return;
            var v = queue.Dequeue();
            path.Add(v);

            GetVertexEdgesB(v, ref queue, ref path, VTo);

            StartBreadthFirstSearch(VTo, ref queue, ref path);
        }
        private void GetVertexEdgesB(Vertex v, ref System.Collections.Generic.Queue<Vertex> queue, ref List<Vertex> path, int VTo)
        {
            for (int i = 0; i < vertex.Length; i++)
            {
                if (vertex[i].Hit == true) continue;

                if (IsEdge(vertex[i].Value, v.Value))
                {
                    vertex[i].Hit = true;
                    queue.Enqueue(vertex[i]);

                    if (vertex[i].Value == VTo)
                    {
                        path.Add(vertex[i]);
                        queue.Clear();
                        break;
                    }
                }
            }
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
