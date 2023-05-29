namespace ShortesPathAlgorithm.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DijkstraShortestPath_Testcase1_ReturnsCorrectDistances()
        {
            // Arrange
            int vertices = 6;
            Graph graph = new Graph(vertices);

            graph.AddEdge(0, 1, 4);
            graph.AddEdge(0, 2, 3);
            graph.AddEdge(1, 3, 2);
            graph.AddEdge(1, 2, 1);
            graph.AddEdge(2, 3, 4);
            graph.AddEdge(3, 4, 2);
            graph.AddEdge(4, 5, 6);

            int source = 0;
            int[] expectedDistances = { 0, 4, 3, 6, 8, 14 };

            // Act
            int[] actualDistances = graph.DijkstraShortestPath(source);

            // Assert
            Assert.That(actualDistances, Is.EqualTo(expectedDistances));            
        }

        [Test]
        public void DijkstraShortestPath_Testcase2_ReturnsCorrectDistances()
        {
            // Arrange
            int vertices = 5;
            Graph graph = new Graph(vertices);

            graph.AddEdge(0, 1, 10);
            graph.AddEdge(0, 3, 5);
            graph.AddEdge(1, 2, 1);
            graph.AddEdge(1, 3, 2);
            graph.AddEdge(2, 4, 4);
            graph.AddEdge(3, 1, 3);
            graph.AddEdge(3, 2, 9);
            graph.AddEdge(3, 4, 2);
            graph.AddEdge(4, 0, 7);
            graph.AddEdge(4, 2, 6);

            int source = 0;
            int[] expectedDistances = { 0, 7, 8, 5, 7 };

            // Act
            int[] actualDistances = graph.DijkstraShortestPath(source);

            // Assert
            Assert.That(actualDistances, Is.EqualTo(expectedDistances));
        }

        [Test]
        public void DijkstraShortestPath_Testcase3_ReturnsCorrectDistances()
        {
            // Arrange
            int vertices = 4;
            Graph graph = new Graph(vertices);

            graph.AddEdge(0, 1, 1);
            graph.AddEdge(0, 2, 3);
            graph.AddEdge(1, 2, 1);
            graph.AddEdge(2, 3, 2);

            int source = 0;
            int[] expectedDistances = { 0, 1, 2, 4 };

            // Act
            int[] actualDistances = graph.DijkstraShortestPath(source);

            // Assert
            Assert.That(actualDistances, Is.EqualTo(expectedDistances));
        }

        [Test]
        public void DijkstraShortestPath_Testcase4_ReturnsCorrectDistances()
        {
            // Arrange
            int vertices = 3;
            Graph graph = new Graph(vertices);

            graph.AddEdge(0, 1, 2);
            graph.AddEdge(1, 2, 3);
            graph.AddEdge(2, 0, 1);

            int source = 1;
            int[] expectedDistances = { 2, 0, 3 };

            // Act
            int[] actualDistances = graph.DijkstraShortestPath(source);

            // Assert
            Assert.That(actualDistances, Is.EqualTo(expectedDistances));
        }

        [Test]
        public void DijkstraShortestPath_Testcase5_ReturnsCorrectDistances()
        {
            // Arrange
            int vertices = 4;
            Graph graph = new Graph(vertices);

            graph.AddEdge(0, 1, 1);
            graph.AddEdge(0, 3, 3);
            graph.AddEdge(1, 2, 2);
            graph.AddEdge(2, 3, 1);

            int source = 3;
            int[] expectedDistances = { 3, 3, 1, 0 };

            // Act
            int[] actualDistances = graph.DijkstraShortestPath(source);

            // Assert
            Assert.That(actualDistances, Is.EqualTo(expectedDistances));
        }
    }
}