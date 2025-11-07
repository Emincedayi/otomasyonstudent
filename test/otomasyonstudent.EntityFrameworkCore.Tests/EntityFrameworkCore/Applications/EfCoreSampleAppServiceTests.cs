using otomasyonstudent.Samples;
using Xunit;

namespace otomasyonstudent.EntityFrameworkCore.Applications;

[Collection(otomasyonstudentTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<otomasyonstudentEntityFrameworkCoreTestModule>
{

}
