using context_pkg.Exceptions;

namespace Test.Test.Entities;

public class PermissionsGroupTest
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void NaoDeveCriarPermissionsGroupSemDescrption(string description)
    {
        Assert.Throws<ExceptionCustom>(() => PermissionsGroupBuilder.Init().SemDescription(description).Build());
    }

    [Fact]
    public void NaoDeveCriarPermissionsGroupSemUserGroup()
    {
        Assert.Throws<ExceptionCustom>(() => PermissionsGroupBuilder.Init().SemGroupId(Guid.Empty).Build());
    }
}
