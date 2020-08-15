using Xunit;

namespace Conways.GameOfLife.App.Tests
{
    public class LifeRulesTests
    {
        // Any live cell with fewer than two live neighbours dies, as if by underpopulation.
        // Any live cell with two or three live neighbours lives on to the next generation.
        // Any live cell with more than three live neighbours dies, as if by overpopulation.
        // Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void LiveCell_LessThanTwoLiveNeighbours_Dies(int liveNeighbours)
        {
            // Any live cell with fewer than two live neighbours dies, as if by underpopulation.
            // Arrange
            CellState currentState = CellState.Alive;

            // Act
            CellState result = LifeRules.GetNewState(currentState, liveNeighbours);

            // Assert
            Assert.Equal(CellState.Dead, result);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public void LiveCell_TwoOrThreeLiveNeighbours_Lives(int liveNeighbours)
        {
            // Any live cell with two or three live neighbours lives on to the next generation.
            // Arrange
            CellState currentState = CellState.Alive;

            // Act
            CellState result = LifeRules.GetNewState(currentState, liveNeighbours);

            // Assert
            Assert.Equal(CellState.Alive, result);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        public void LiveCell_MoreThanThreeNeighbours_Dies(int liveNeighbours)
        {
            // Any live cell with more than three live neighbours dies, as if by overpopulation.
            // Arrange
            CellState currentState = CellState.Alive;

            // Act
            CellState result = LifeRules.GetNewState(currentState, liveNeighbours);

            // Assert
            Assert.Equal(CellState.Dead, result);
        }

        [Theory]
        [InlineData(3)]
        public void DeadCell_ExactlyThreeLiveNeighbours_Lives(int liveNeighbours)
        {
            // Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
            // Arrange
            CellState currentState = CellState.Dead;

            // Act
            CellState result = LifeRules.GetNewState(currentState, liveNeighbours);

            // Assert
            Assert.Equal(CellState.Alive, result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        public void DeadCell_LessThanThreeLiveNeighbours_Dies(int liveNeighbours)
        {
            // Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
            // Arrange
            CellState currentState = CellState.Dead;

            // Act
            CellState result = LifeRules.GetNewState(currentState, liveNeighbours);

            // Assert
            Assert.Equal(CellState.Dead, result);
        }
    }
}
