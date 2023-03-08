using System;
using Moq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using WolfRPG.Core;

namespace WolfRPG.Inventory.Tests
{
	public class ItemContainerTests
	{
		[Test]
		public void AddItem_AddsItemToExpectedSlot()
		{
			var rpgDatabase = new Mock<IRPGDatabase>();
			var target = new ItemContainer(rpgDatabase.Object);

			var itemObject = new RPGObject();
			var expected = itemObject.AddComponent<ItemData>();
			
			target.AddItem(itemObject);

			var actual = target.GetItemBySlot(0);
			Assert.AreEqual(expected, actual);
		}

		[Test]
		public void AddItem_IncreasesQuantity()
		{
			var rpgDatabase = new Mock<IRPGDatabase>();
			var target = new ItemContainer(rpgDatabase.Object);
			
			var itemObject = new RPGObject();
			var itemData = itemObject.AddComponent<ItemData>();
			
			target.AddItem(itemObject);

			var actual = target.GetQuantityFromSlot(0);
			Assert.AreEqual(1, actual);
			
			target.AddItem(itemObject);
			
			actual = target.GetQuantityFromSlot(0);
			Assert.AreEqual(2, actual);
		}
		
		[Test]
		public void AddItem_ObjectHasNoItemDataComponent_LogsError()
		{
			var rpgDatabase = new Mock<IRPGDatabase>();
			var target = new ItemContainer(rpgDatabase.Object);
			
			var itemObject = new RPGObject();
			
			LogAssert.Expect(LogType.Error, "Object is not a valid item");
			target.AddItem(itemObject);
		}
		
		[Test]
		public void AddItemGuid_AddsItemToExpectedSlot()
		{
			var rpgDatabase = new Mock<IRPGDatabase>();
			var target = new ItemContainer(rpgDatabase.Object);

			var guid = Guid.NewGuid().ToString();
			var itemObject = new RPGObject
			{
				Guid = guid
			};
			var expected = itemObject.AddComponent<ItemData>();
			rpgDatabase.Setup(x => x.GetObjectInstance(guid)).Returns(itemObject);
			
			target.AddItem(itemObject.Guid);

			var actual = target.GetItemBySlot(0);
			Assert.AreEqual(expected, actual);
		}
		
		[Test]
		public void AddItemGuid_IncreasesQuantity()
		{
			var rpgDatabase = new Mock<IRPGDatabase>();
			var target = new ItemContainer(rpgDatabase.Object);

			var guid = Guid.NewGuid().ToString();
			var itemObject = new RPGObject
			{
				Guid = guid
			};
			var itemData = itemObject.AddComponent<ItemData>();
			rpgDatabase.Setup(x => x.GetObjectInstance(guid)).Returns(itemObject);
			
			target.AddItem(guid);

			var actual = target.GetQuantityFromSlot(0);
			Assert.AreEqual(1, actual);
			
			target.AddItem(itemObject);
			
			actual = target.GetQuantityFromSlot(0);
			Assert.AreEqual(2, actual);
		}
		
		[Test]
		public void AddItemGuid_ObjectHasNoItemDataComponent_LogsError()
		{
			var rpgDatabase = new Mock<IRPGDatabase>();
			var target = new ItemContainer(rpgDatabase.Object);
			
			var guid = Guid.NewGuid().ToString();
			var itemObject = new RPGObject
			{
				Guid = guid
			};
			rpgDatabase.Setup(x => x.GetObjectInstance(guid)).Returns(itemObject);
			
			LogAssert.Expect(LogType.Error, "Object is not a valid item");
			target.AddItem(guid);
		}
		
		[Test]
		public void AddItemGuid_ObjectNotFound_LogsError()
		{
			var rpgDatabase = new Mock<IRPGDatabase>();
			var target = new ItemContainer(rpgDatabase.Object);
			
			var guid = Guid.NewGuid().ToString();

			LogAssert.Expect(LogType.Error, "Object was not found in database");
			target.AddItem(guid);
		}

	}
}