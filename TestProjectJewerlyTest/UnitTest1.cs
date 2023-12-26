using Project_partB_Sorokin_program;

namespace TestProjectJewelryTest
{
    [TestClass]
    public class PreciousStoneTests
    {
        [TestMethod]
        public void GetName_ShouldReturnCorrectName()
        {
            // Arrange
            var preciousStone = new PreciousStone(PreciousGemstoneName.Diamond, 1.0, 1000m, "Clear", 10);

            // Act
            var name = preciousStone.GetName();

            // Assert
            Assert.AreEqual("Diamond", name);
        }

        [TestMethod]
        public void GetWeight_ShouldReturnCorrectWeight()
        {
            // Arrange
            var preciousStone = new PreciousStone(PreciousGemstoneName.Diamond, 1.0, 1000m, "Clear", 10);

            // Act
            var weight = preciousStone.GetWeight();

            // Assert
            Assert.AreEqual(1.0, weight);
        }

        [TestMethod]
        public void GetValue_ShouldReturnCorrectValue()
        {
            // Arrange
            var preciousStone = new PreciousStone(PreciousGemstoneName.Diamond, 1.0, 1000m, "Clear", 10);

            // Act
            var value = preciousStone.GetValue();

            // Assert
            Assert.AreEqual(1000m, value);
        }

        [TestMethod]
        public void GetColor_ShouldReturnCorrectColor()
        {
            // Arrange
            var preciousStone = new PreciousStone(PreciousGemstoneName.Diamond, 1.0, 1000m, "Clear", 10);

            // Act
            var color = preciousStone.GetColor();

            // Assert
            Assert.AreEqual("Clear", color);
        }

        [TestMethod]
        public void GetDetails_ShouldReturnCorrectDetails()
        {
            // Arrange
            var preciousStone = new PreciousStone(PreciousGemstoneName.Diamond, 1.0, 1000, "Clear", 10);
            var expectedDetails = "Name: Diamond, Clarity: 10";

            // Act
            var details = preciousStone.GetDetails();

            // Assert
            Assert.AreEqual(expectedDetails, details);
        }

        // Тест для проверки корректности метода ToString.
        [TestMethod]
        public void ToString_ShouldReturnCorrectStringRepresentation()
        {
            // Arrange
            var preciousStone = new PreciousStone(PreciousGemstoneName.Diamond, 1, 1000m, "Clear", 10);
            var expectedString = $"Name: Diamond, Weight: 1 carats, Price: $1000, Color: Clear, Clarity: 10";

            // Act
            var result = preciousStone.ToString();

            // Assert
            Assert.AreEqual(expectedString, result);
        }
    }


    [TestClass]
    public class NecklaceTests
    {
        [TestMethod]
        public void RemoveStone_ShouldRemoveStone()
        {
            // Arrange
            var necklace = new Necklace();
            var stone = new SemiPreciousStone(SemiPreciousGemstoneName.Amethyst, 9, 9m, "green", 9);
            necklace.AddStone(stone);

            // Act
            necklace.RemoveStone(stone);

            // Assert
            Assert.IsFalse(necklace.Contains(stone));
        }

        [TestMethod]
        public void AddStone_ShouldAddStone()
        {
            // Arrange
            var necklace = new Necklace();
            var stone = new PreciousStone(PreciousGemstoneName.Diamond, 9, 9m, "green", 9);

            // Act
            necklace.AddStone(stone);

            // Assert
            Assert.IsTrue(necklace.Contains(stone));
        }

        [TestMethod]
        public void GetTotalValue_ShouldReturnCorrectTotalValue()
        {
            // Arrange
            var necklace = new Necklace();
            var stone1 = new SemiPreciousStone(SemiPreciousGemstoneName.Amethyst, 1, 100m, "green", 7);
            var stone2 = new PreciousStone(PreciousGemstoneName.Diamond, 1, 1000m, "green", 10);
            necklace.AddStone(stone1);
            necklace.AddStone(stone2);
            decimal expectedTotalValue = 100m + 1000m; // Ожидаемая общая стоимость

            // Act
            var totalValue = necklace.GetTotalValue();

            // Assert
            Assert.AreEqual(expectedTotalValue, totalValue);
        }

        [TestMethod]
        public void FindStonesByColor_ShouldReturnStonesOfSpecifiedColor()
        {
            // Arrange
            var necklace = new Necklace();
            var stone1 = new SemiPreciousStone(SemiPreciousGemstoneName.Amethyst, 1, 100m, "blue", 7);
            var stone2 = new PreciousStone(PreciousGemstoneName.Diamond, 1, 1000m, "green", 10);
            necklace.AddStone(stone1);
            necklace.AddStone(stone2);

            // Act
            var foundStones = necklace.FindStonesByColor("blue");

            // Assert
            Assert.IsTrue(foundStones.Any(stone => stone.GetColor() == "blue"));
        }

        [TestMethod]
        public void GetTotalWeight_ShouldReturnCorrectTotalWeight()
        {
            // Arrange
            var necklace = new Necklace();
            var stone1 = new SemiPreciousStone(SemiPreciousGemstoneName.Amethyst, 1, 100m, "green", 7);
            var stone2 = new PreciousStone(PreciousGemstoneName.Diamond, 1, 1000m, "green", 10);
            necklace.AddStone(stone1);
            necklace.AddStone(stone2);
            double expectedTotalWeight = 1 + 1; // Ожидаемый общий вес

            // Act
            var totalWeight = necklace.GetTotalWeight();

            // Assert
            Assert.AreEqual(expectedTotalWeight, totalWeight);
        }

        [TestMethod]
        public void SortByValue_ShouldSortStonesByValue()
        {
            // Arrange
            var necklace = new Necklace();
            var stone1 = new SemiPreciousStone(SemiPreciousGemstoneName.Amethyst, 1, 100m, "green", 7);
            var stone2 = new PreciousStone(PreciousGemstoneName.Diamond, 1, 1000m, "green", 10);
            necklace.AddStone(stone2); // Добавляем более ценный камень первым
            necklace.AddStone(stone1);

            // Act
            necklace.SortByValue();

            // Assert
            var sortedStones = necklace.GetStones();
            Assert.AreEqual(sortedStones[0], stone1); // После сортировки дешевый камень должен быть первым
            Assert.AreEqual(sortedStones[1], stone2); // Затем идёт более ценный
        }

        [TestMethod]
        public void ToString_ShouldReturnCorrectStringRepresentation()
        {
            // Arrange
            var necklace = new Necklace();
            var stone = new SemiPreciousStone(SemiPreciousGemstoneName.Amethyst, 1, 100m, "green", 7);
            necklace.AddStone(stone);

            // Act
            var result = necklace.ToString();

            // Assert
            string expectedString = "Necklace contains the following stones:\n" + stone.ToString() + "\n";

            Assert.AreEqual(expectedString, result);
        }

        // Тест для проверки поведения при добавлении null в качестве камня.
        [TestMethod]
        public void AddStone_WhenNull_ShouldNotAddStone()
        {
            // Arrange
            var necklace = new Necklace();

            // Act
            necklace.AddStone(null);

            // Assert
            Assert.AreEqual(0, necklace.GetStones().Count);
        }

        // Тест для проверки поведения при удалении null.
        [TestMethod]
        public void RemoveStone_WhenNull_ShouldNotRemoveStone()
        {
            // Arrange
            var necklace = new Necklace();
            var stone = new SemiPreciousStone(SemiPreciousGemstoneName.Amethyst, 1, 100m, "Purple", 7);
            necklace.AddStone(stone);

            // Act
            necklace.RemoveStone(null);

            // Assert
            Assert.IsTrue(necklace.Contains(stone));
        }

        // Тест для проверки сортировки пустой коллекции.
        [TestMethod]
        public void SortByValue_WhenCollectionIsEmpty_ShouldNotFail()
        {
            // Arrange
            var necklace = new Necklace();

            // Act
            necklace.SortByValue();

            // Assert
            Assert.AreEqual(0, necklace.GetStones().Count);
        }

        // Тест для проверки поиска камней по цвету, которых нет в коллекции.
        [TestMethod]
        public void FindStonesByColor_WhenColorNotPresent_ShouldReturnEmptyCollection()
        {
            // Arrange
            var necklace = new Necklace();
            var stone = new SemiPreciousStone(SemiPreciousGemstoneName.Amethyst, 1, 100m, "Purple", 7);
            necklace.AddStone(stone);

            // Act
            var result = necklace.FindStonesByColor("Red");

            // Assert
            Assert.IsFalse(result.Any());
        }
    }


    [TestClass]
    public class SemiPreciousStoneTests
    {
        [TestMethod]
        public void Constructor_ShouldSetProperties()
        {
            // Arrange
            var expectedName = SemiPreciousGemstoneName.Amethyst;
            double expectedCaratWeight = 2.0;
            decimal expectedPrice = 150m;
            string expectedColor = "Purple";
            int expectedHardness = 7;

            // Act
            SemiPreciousStone semiPreciousStone = new SemiPreciousStone(expectedName, expectedCaratWeight, expectedPrice, expectedColor, expectedHardness);

            // Assert
            Assert.AreEqual(expectedName.ToString(), semiPreciousStone.Name);
            Assert.AreEqual(expectedCaratWeight, semiPreciousStone.CaratWeight);
            Assert.AreEqual(expectedPrice, semiPreciousStone.Price);
            Assert.AreEqual(expectedColor, semiPreciousStone.Color);
            Assert.AreEqual(expectedHardness, semiPreciousStone.Hardness);
        }

        [TestMethod]
        public void GetName_ShouldReturnCorrectName()
        {
            // Arrange
            SemiPreciousStone stone = new SemiPreciousStone(SemiPreciousGemstoneName.Amethyst, 2.0, 150m, "Purple", 7);

            // Act
            string name = stone.GetName();

            // Assert
            Assert.AreEqual(SemiPreciousGemstoneName.Amethyst.ToString(), name);
        }

        [TestMethod]
        public void GetWeight_ShouldReturnCorrectWeight()
        {
            // Arrange
            SemiPreciousStone stone = new SemiPreciousStone(SemiPreciousGemstoneName.Amethyst, 2.0, 150m, "Purple", 7);

            // Act
            double weight = stone.GetWeight();

            // Assert
            Assert.AreEqual(2.0, weight);
        }

        [TestMethod]
        public void GetValue_ShouldReturnCorrectValue()
        {
            // Arrange
            SemiPreciousStone stone = new SemiPreciousStone(SemiPreciousGemstoneName.Amethyst, 2.0, 150m, "Purple", 7);

            // Act
            decimal value = stone.GetValue();

            // Assert
            Assert.AreEqual(150m, value);
        }

        [TestMethod]
        public void GetColor_ShouldReturnCorrectColor()
        {
            // Arrange
            SemiPreciousStone stone = new SemiPreciousStone(SemiPreciousGemstoneName.Amethyst, 2.0, 150m, "Purple", 7);

            // Act
            string color = stone.GetColor();

            // Assert
            Assert.AreEqual("Purple", color);
        }

        [TestMethod]
        public void GetDetails_ShouldReturnCorrectDetails()
        {
            // Arrange
            SemiPreciousStone stone = new SemiPreciousStone(SemiPreciousGemstoneName.Amethyst, 2.0, 150m, "Purple", 7);
            var expectedDetails = "Name: Amethyst, Hardness: 7 on Mohs scale";

            // Act
            string details = stone.GetDetails();

            // Assert
            Assert.AreEqual(expectedDetails, details);
        }

        // Тест для проверки корректности метода ToString.
        [TestMethod]
        public void ToString_ShouldReturnCorrectStringRepresentation()
        {
            // Arrange
            var semiPreciousStone = new SemiPreciousStone(SemiPreciousGemstoneName.Amethyst, 2, 150m, "Purple", 7);
            var expectedString = $"Name: Amethyst, Weight: 2 carats, Price: $150, Color: Purple, Hardness: 7 on Mohs scale";

            // Act
            var result = semiPreciousStone.ToString();

            // Assert
            Assert.AreEqual(expectedString, result);
        }
    }


    [TestClass]
    public class StoneTests
    {
        // Тест для проверки сравнения цены камней.
        [TestMethod]
        public void CompareTo_ShouldCorrectlyCompareStonesByPrice()
        {
            // Arrange
            var stone1 = new SemiPreciousStone(SemiPreciousGemstoneName.Amethyst, 1, 100m, "Purple", 7);
            var stone2 = new SemiPreciousStone(SemiPreciousGemstoneName.Citrine, 1, 150m, "Yellow", 6);

            // Act & Assert
            Assert.IsTrue(stone1.CompareTo(stone2) < 0);
            Assert.IsTrue(stone2.CompareTo(stone1) > 0);
            Assert.AreEqual(0, stone1.CompareTo(stone1));
        }
    }



}