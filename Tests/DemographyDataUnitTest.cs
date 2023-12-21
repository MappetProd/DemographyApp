using System.Data;
using Demography.Domain;


namespace Tests;

public class DemographyDataUnitTest
{
    [Fact]
    public void VoidTest()
    {
        var testHelper = new TestHelper();
        var demographyDataRepository = testHelper.DemographyDataRepository;
        Assert.Equal(1, 1);
    }


    [Fact]
    public async Task TestAdd()
    {

        var testHelper = new TestHelper();
        var demographyDataRepository = testHelper.DemographyDataRepository;

        var region = new Region { Id = Guid.NewGuid(), Name = "TestRegion2" };
        await testHelper.RegionRepository.AddAsync(region);

        var demographyData = new DemographyData { Id = Guid.NewGuid(), RegionId = region.Id };

        await demographyDataRepository.AddAsync(demographyData);

        demographyDataRepository.ChangeTrackerClear();

        var allDemographyData = await demographyDataRepository.GetAllAsync();

        Assert.Equal(2, allDemographyData.Count);

    }


    [Fact]
    public async Task TestUpdateDemographyData()
    {
        var testHelper = new TestHelper();

        var region = new Region { Id = Guid.NewGuid(), Name = "TestRegion3" };
        await testHelper.RegionRepository.AddAsync(region);

        var demographyDataRepository = testHelper.DemographyDataRepository;

        var initialDemographyData = new DemographyData
        {
            Id = Guid.NewGuid(),
            RegionId = region.Id,
            Year = 2022,
        };
        
        var addedDemographyData = await demographyDataRepository.AddAsync(initialDemographyData);

        var reloadedDemographyData = await demographyDataRepository.GetByIdAsync(addedDemographyData.Id);


        Assert.NotNull(reloadedDemographyData);
        reloadedDemographyData.Year = 2023;

        await demographyDataRepository.UpdateAsync(reloadedDemographyData);

        Assert.Equal(2023, reloadedDemographyData.Year);
    }

    [Fact]
    public async Task TestUpdateDelete()
    {
        var testHelper = new TestHelper();

        var region = new Region { Id = Guid.NewGuid(), Name = "TestRegion4" };
        await testHelper.RegionRepository.AddAsync(region);
        
        var demographyDataRepository = testHelper.DemographyDataRepository;

        var initialDemographyData = new DemographyData
        {
            Id = Guid.NewGuid(),
            RegionId = region.Id,
            Year = 2022,
        };

        var addedDemographyData = await demographyDataRepository.AddAsync(initialDemographyData);

        demographyDataRepository.ChangeTrackerClear();

        await demographyDataRepository.DeleteAsync(addedDemographyData.Id);

        var deletedDemographyData = await demographyDataRepository.GetByIdAsync(addedDemographyData.Id);

        Assert.Null(deletedDemographyData);
    }
}