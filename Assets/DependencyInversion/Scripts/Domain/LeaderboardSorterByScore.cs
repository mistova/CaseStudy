namespace CaseStudyDependencyInversion.Unity.Domain
{
	using CaseStudyDependencyInversion.Unity.Domain.Model;
	using System.Collections.Generic;
	using System.Linq;

	public class LeaderboardSorterByScore : Sorter
	{
		public IEnumerable<LeaderboardItem> Sort(FakeLeaderboardProvider leaderboardProvider)
        {
			return SortbyScore(leaderboardProvider);
        }

		public IEnumerable<LeaderboardItem> SortbyScore(FakeLeaderboardProvider leaderboardProvider) =>
			leaderboardProvider.GetItems().OrderByDescending(i => i.Score);
	}
}
