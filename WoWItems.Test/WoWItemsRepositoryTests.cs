using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.VisualBasic;
using Moq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.Xml;
using WoWItems.API.Controllers;
using WoWItems.API.DbContexts;
using WoWItems.API.Entities;
using WoWItems.API.Models;
using WoWItems.API.Profiles;
using WoWItems.API.Services;
using Xunit;

namespace WoWItems.Test
{
    public class WoWItemsRepositoryTests
    {
        [Fact]
        public async Task  GetItemsAsync_PaginationVerification()
        {
            var ListOfItems = new List<Item>()
            {
                new Item("RandomItem1"),
                new Item("RandomItem2")
            };
            var woWItemRepositoryMock = new Mock<IWoWItemsRepository>();
            var mapper = new Mock<IMapper>();
            //woWItemRepositoryMock.Setup(m => m.GetItemsAsync())
            //    .ReturnsAsync(ListOfItems);
            var wowItemDbContextMock = new Mock<WoWItemsContext>();
            //wowItemDbContextMock.Setup(m => m.Items.Where().Returns(ListOfItems);
            var itemController = new ItemsController(woWItemRepositoryMock.Object, mapper.Object);
            var pagedItems = itemController.GetItems(string.Empty, null, null, 2, 1);

            var objectResult = Assert.IsType<ActionResult<IEnumerable<ItemDto>>>(pagedItems.Result);
            var okObjectResult = Assert.IsType<OkObjectResult>(objectResult.Result);
            var valuedData = Assert.IsType<ItemDto[]>(okObjectResult.Value);
            Assert.True(valuedData.Length==1);
        }

        [Fact]
        public async Task GetItemsAsync_FilterByName()
        {

        }



    }
}