﻿namespace SynetecAssessmentApi.Domain.Entities.Base
{
    public abstract class Entity
    {
        public int Id { get; set; }

        public Entity(int id)
        {
            Id = id;
        }
    }
}
