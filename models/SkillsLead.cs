﻿using System;


namespace models
{
    public class SkillsLead: IEntity
    {
        public int Id { get; set; }
        public int LeadId { get; set; }
        public Lead Lead { get; set; }
        public int SkillsId { get; set; }
        public Skills Skill { get; set; }



        public enum Fields
        {
            Id,
            LeadId,
            SkillsId
        }
    }

}
