﻿using System;
using System.Collections.Generic;

namespace GangOfFour.Creational
{
    public interface ISection
    {
        void Describe();
    }

    public class PersonalSection : ISection
    {
        public void Describe() => Console.WriteLine("Personal Section");
    }

    public class AlbumSection : ISection
    {
        public void Describe() => Console.WriteLine("Album Section");
    }

    public class PatentSection : ISection
    {
        public void Describe() => Console.WriteLine("Patent Section");
    }

    public class PublicationSection : ISection
    {
        public void Describe() => Console.WriteLine("Publication Section");
    }

    public abstract class Profile
    {
        protected Profile() => CreateProfile();

        public List<ISection> Sections { get; private set; }

        protected void AddSections(ISection section)
        {
            if (Sections == null)
                Sections = new List<ISection>();
            Sections.Add(section);
        }

        protected abstract void CreateProfile();
    }

    public class Facebook : Profile
    {
        protected override void CreateProfile()
        {
            AddSections(new PersonalSection());
            AddSections(new AlbumSection());
        }
    }

    public class LinkedIn : Profile
    {
        protected override void CreateProfile()
        {
            AddSections(new PersonalSection());
            AddSections(new PatentSection());
            AddSections(new PublicationSection());
        }
    }

    #if (FACTORY == true) && (ABSTRACT_FACTORY == false)
    class MainProgram
    {
        static void Main(string[] args)
        {
            Console.Write("Which Profile would you like to create - LinkedIn or Facebook?\n>> ");
            string profile_type = args[0];

            Profile profile;
            if (profile_type == "Facebook")
            {
                profile = new Facebook();
            }
            else if (profile_type == "LinkedIn")
            {
                profile = new LinkedIn();
            }
            else
            {
                throw new InvalidOperationException();
            }

            Console.WriteLine($"Creating {profile_type} Profile...");
            Console.WriteLine("Profile has sections --");
            foreach (ISection section in profile.Sections)
            {
                Console.Write('\t');
                section.Describe();
            }
        }
    }
    #endif
}