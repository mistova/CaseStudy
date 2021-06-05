namespace CaseStudyDependencyInversion.Unity.Domain
{
    using System.Collections.Generic;
    using CaseStudyDependencyInversion.Unity.Domain.Model;
    public interface Sorter
    {
        IEnumerable<LeaderboardItem> Sort(FakeLeaderboardProvider leaderboardProvider);
    }
}
