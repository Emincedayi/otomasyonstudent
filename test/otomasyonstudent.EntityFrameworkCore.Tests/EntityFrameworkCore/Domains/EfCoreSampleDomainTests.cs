using otomasyonstudent.Samples;
using Xunit;

namespace otomasyonstudent.EntityFrameworkCore.Domains;

[Collection(otomasyonstudentTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<otomasyonstudentEntityFrameworkCoreTestModule>
{

}
