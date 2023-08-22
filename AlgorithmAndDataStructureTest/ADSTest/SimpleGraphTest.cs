using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleApp;
using System.Threading.Tasks;
using System.Diagnostics;

namespace joolTest.ADS_2_Test
{
    [TestClass]
    public class SimpleGraphTest
    {
        [TestMethod]
        public void TestAddVertex()
        {
            SimpleGraph simpleGraph = new SimpleGraph(5);

            simpleGraph.AddVertex(0);
            simpleGraph.AddVertex(1);
            simpleGraph.AddVertex(2);
            simpleGraph.AddVertex(3);
            simpleGraph.AddVertex(4);

            simpleGraph.AddVertex(5); // переполнение
        }

        [TestMethod]
        public void TestAddVertexToZeroSizeVertex()
        {
            SimpleGraph simpleGraph = new SimpleGraph(0);

            simpleGraph.AddVertex(1);
            simpleGraph.AddVertex(2);
            simpleGraph.AddVertex(3);
            simpleGraph.AddVertex(4);
        }

        [TestMethod]
        public void TestAddEdgeIsEdgeRemoveEdge()
        {
            SimpleGraph simpleGraph = new SimpleGraph(5);

            simpleGraph.AddVertex(0);
            simpleGraph.AddVertex(1);
            simpleGraph.AddVertex(2);
            simpleGraph.AddVertex(3);
            simpleGraph.AddVertex(4);

            // AddEdge
            simpleGraph.AddEdge(0, 1);
            simpleGraph.AddEdge(0, 4);

            simpleGraph.AddEdge(1, 0); // не обязательно указывать обратную связь
            simpleGraph.AddEdge(1, 4);
            simpleGraph.AddEdge(1, 3);
            simpleGraph.AddEdge(1, 2);

            simpleGraph.AddEdge(3, 2);
            simpleGraph.AddEdge(3, 4);

            // IsEdge
            Assert.IsTrue(simpleGraph.IsEdge(3, 4));
            Assert.IsTrue(simpleGraph.IsEdge(4, 3));

            Assert.IsTrue(simpleGraph.IsEdge(1, 2));
            Assert.IsTrue(simpleGraph.IsEdge(2, 1));

            Assert.IsTrue(simpleGraph.IsEdge(0, 1));

            Assert.IsFalse(simpleGraph.IsEdge(4, 2));

            // removeEdge
            simpleGraph.RemoveEdge(0, 1);
            Assert.IsFalse(simpleGraph.IsEdge(0, 1));

            simpleGraph.RemoveEdge(3, 1);
            Assert.IsFalse(simpleGraph.IsEdge(3, 1));

            simpleGraph.RemoveEdge(3, 4);
            Assert.IsFalse(simpleGraph.IsEdge(3, 4));
        }

        [TestMethod]
        public void TestRemoveVertex()
        {
            SimpleGraph simpleGraph = new SimpleGraph(5);

            simpleGraph.AddVertex(0);
            simpleGraph.AddVertex(1);
            simpleGraph.AddVertex(2);
            simpleGraph.AddVertex(3);
            simpleGraph.AddVertex(4);

            // AddEdge
            simpleGraph.AddEdge(0, 1);
            simpleGraph.AddEdge(0, 4);

            simpleGraph.AddEdge(1, 0); // не обязательно указывать обратную связь
            simpleGraph.AddEdge(1, 4);
            simpleGraph.AddEdge(1, 3);
            simpleGraph.AddEdge(1, 2);

            simpleGraph.AddEdge(3, 2);
            simpleGraph.AddEdge(3, 4);

            int[,] matrix0 = new int[,]
            {
                {0, 1, 0, 0, 1},
                {1, 0, 1, 1, 1},
                {0, 1, 0, 1, 0},
                {0, 1, 1, 0, 1},
                {1, 1, 0, 1, 0},
            };
            for (int i = 0; i < simpleGraph.max_vertex; i++)
                for (int j = 0; j < simpleGraph.max_vertex; j++)
                {
                    Assert.AreEqual(matrix0[i, j], simpleGraph.m_adjacency[i, j]);
                }

            simpleGraph.RemoveEdge(1, 4);
            var res = simpleGraph.DepthFirstSearch(1, 4);



            ////// REMOVE //////
            simpleGraph.RemoveVertex(3); // сравнивать результат с примерной матрицей вместо кв будет лучше
            int[,] matrix = new int[,]
            {
                {0, 1, 0, 1},
                {1, 0, 1, 1},
                {0, 1, 0, 0},
                {1, 1, 0, 0},
            };
            for (int i = 0; i < simpleGraph.max_vertex; i++)
                for (int j = 0; j < simpleGraph.max_vertex; j++)
                {
                    Assert.AreEqual(matrix[i, j], simpleGraph.m_adjacency[i, j]);
                }

            simpleGraph.RemoveVertex(4);
            int[,] matrix1 = new int[,]
            {
                {0, 1, 0},
                {1, 0, 1},
                {0, 1, 0},
            };
            for (int i = 0; i < simpleGraph.max_vertex; i++)
                for (int j = 0; j < simpleGraph.max_vertex; j++)
                {
                    Assert.AreEqual(matrix1[i, j], simpleGraph.m_adjacency[i, j]);
                }


            simpleGraph.RemoveVertex(0);
            int[,] matrix2 = new int[,]
            {
                {0, 1},
                {1, 0},
            };
            for (int i = 0; i < simpleGraph.max_vertex; i++)
                for (int j = 0; j < simpleGraph.max_vertex; j++)
                {
                    Assert.AreEqual(matrix2[i, j], simpleGraph.m_adjacency[i, j]);
                }


            simpleGraph.RemoveVertex(1);
            int[,] matrix3 = new int[,]
            {
                {0},
            };
            for (int i = 0; i < simpleGraph.max_vertex; i++)
                for (int j = 0; j < simpleGraph.max_vertex; j++)
                {
                    Assert.AreEqual(matrix3[i, j], simpleGraph.m_adjacency[i, j]);
                }

            simpleGraph.RemoveVertex(2);
            int[,] matrix4 = new int[,]
            {
                {},
            };
            for (int i = 0; i < simpleGraph.max_vertex; i++)
                for (int j = 0; j < simpleGraph.max_vertex; j++)
                {
                    Assert.AreEqual(matrix4[i, j], simpleGraph.m_adjacency[i, j]);
                }
        }

        SimpleGraph simpleGraph2 = new SimpleGraph(5);

        [TestMethod]
        public void AddVertex_AddingVertextoGraph_Success()
        {
            simpleGraph2.AddVertex(1);

            Assert.AreEqual(1, simpleGraph2.vertex[0].Value);
        }

        [TestMethod]
        public void RemoveVertex_RemovingVertexFromGraph_Success()
        {
            simpleGraph2.RemoveVertex(0);

            Assert.IsNull(simpleGraph2.vertex[0]);
        }

        [TestMethod]
        public void IsEdge_CheckingIfEdgeBetweenTwoVerticesExists_Success()
        {
            simpleGraph2.AddVertex(1);
            simpleGraph2.AddVertex(2);
            simpleGraph2.AddEdge(1, 2);

            Assert.IsTrue(simpleGraph2.IsEdge(1, 2));
        }

        [TestMethod]
        public void AddEdge_AddingEdgeBetweenTwoVertices_Success()
        {
            simpleGraph2.AddVertex(1);
            simpleGraph2.AddVertex(2);
            simpleGraph2.AddEdge(1, 2);

            Assert.AreEqual(1, simpleGraph2.m_adjacency[0, 1]);
        }

        [TestMethod]
        public void RemoveEdge_RemovingEdgeBetweenTwoVertices_Success()
        {
            simpleGraph2.AddVertex(1);
            simpleGraph2.AddVertex(2);
            simpleGraph2.AddEdge(1, 2);
            simpleGraph2.RemoveEdge(1, 2);

            Assert.AreEqual(0, simpleGraph2.m_adjacency[0, 1]);
        }

        [TestMethod]
        public void DepthFirstSearchTest()
        {
            SimpleGraph simpleGraph = new SimpleGraph(6);

            simpleGraph.AddVertex(1);
            simpleGraph.AddVertex(2);
            simpleGraph.AddVertex(3);
            simpleGraph.AddVertex(4);
            simpleGraph.AddVertex(5);
            simpleGraph.AddVertex(6);

            simpleGraph.AddEdge(1, 2);
            simpleGraph.AddEdge(1, 3);

            simpleGraph.AddEdge(2, 4);
            simpleGraph.AddEdge(2, 5);

            simpleGraph.AddEdge(5, 3);
            simpleGraph.AddEdge(4, 6);
            simpleGraph.AddEdge(5, 6);
            simpleGraph.AddEdge(5, 4);

            //var res2 = simpleGraph.DepthFirstSearch(3, 4);
            //var res = simpleGraph.DepthFirstSearch(1, 6);
            //var res1 = simpleGraph.DepthFirstSearch(3, 2);
            //var res5 = simpleGraph.DepthFirstSearch(2, 6);
            //var res3 = simpleGraph.DepthFirstSearch(5, 4);
            //var res4 = simpleGraph.DepthFirstSearch(1, 5);
            //var res6 = simpleGraph.DepthFirstSearch(2, 5);
            //var res7 = simpleGraph.DepthFirstSearch(6, 1);
        }

        [TestMethod]
        public void BreadthFirstSearchTest()
        {
            SimpleGraph simpleGraph = new SimpleGraph(6);

            simpleGraph.AddVertex(1);
            simpleGraph.AddVertex(2);
            simpleGraph.AddVertex(3);
            simpleGraph.AddVertex(4);
            simpleGraph.AddVertex(5);
            simpleGraph.AddVertex(6);

            simpleGraph.AddEdge(1, 2);
            simpleGraph.AddEdge(1, 3);

            simpleGraph.AddEdge(2, 4);
            simpleGraph.AddEdge(2, 5);

            simpleGraph.AddEdge(5, 3);
            simpleGraph.AddEdge(4, 6);
            simpleGraph.AddEdge(5, 6);
            simpleGraph.AddEdge(5, 4);

            //var res = simpleGraph.BreadthFirstSearch(4, 3);
            //var res = simpleGraph.BreadthFirstSearch(5, 1);
            //var res = simpleGraph.BreadthFirstSearch(6, 3);
            //var res = simpleGraph.BreadthFirstSearch(4, 3);
            //var res = simpleGraph.BreadthFirstSearch(6, 2);
            //var res = simpleGraph.BreadthFirstSearch(6, 1);

        }

        [TestMethod]
        public void WeakVerticesTest()
        {
            SimpleGraph simpleGraph = new SimpleGraph(9);

            simpleGraph.AddVertex(1);
            simpleGraph.AddVertex(2);
            simpleGraph.AddVertex(3);
            simpleGraph.AddVertex(4);
            simpleGraph.AddVertex(5);
            simpleGraph.AddVertex(6);
            simpleGraph.AddVertex(7);
            simpleGraph.AddVertex(8);
            simpleGraph.AddVertex(9);

            simpleGraph.AddEdge(1, 2);
            simpleGraph.AddEdge(1, 3);
            simpleGraph.AddEdge(1, 5);
            simpleGraph.AddEdge(2, 3);
            simpleGraph.AddEdge(2, 4);
            simpleGraph.AddEdge(3, 4);
            simpleGraph.AddEdge(3, 6);
            simpleGraph.AddEdge(5, 6);
            simpleGraph.AddEdge(8, 6);
            simpleGraph.AddEdge(8, 9);
            simpleGraph.AddEdge(7, 6);
            simpleGraph.AddEdge(7, 8);

            var res = simpleGraph.WeakVertices();
        }
    }
}
