using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace JyGame
{
	public class Story 
	{
        public string Name;

        public List<StoryAction> Actions = new List<StoryAction>();

        public List<StoryResult> Results = new List<StoryResult>();
    }
}
