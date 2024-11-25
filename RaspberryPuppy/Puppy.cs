namespace RaspberryPuppy
{
	public class Puppy
	{
        public int ID { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public int Age { get; set; }
        public bool NeedToWalk { get; set; }
        public SoundSignal Sounds { get; set; }

        public enum SoundSignal
        {
            Silent = 0,
            LoudBarking = 1,
            QuietBarking = 2
        }

        public Puppy()
        {

        }

        public Puppy(int id, string name, string race, int age, bool needToWalk, SoundSignal sounds)
        {
            ID = id;
            Name = name;
            Race = race;
            Age = age;
            NeedToWalk = needToWalk;
            Sounds = sounds;
        }

        public override string ToString()
        {
            return $"{{{nameof(ID)}={ID}, {nameof(Name)}={Name}, {nameof(Race)}={Race}, {nameof(Age)}={Age}, {nameof(NeedToWalk)}={NeedToWalk}, {nameof(Sounds)}={Sounds.ToString()}}}";
        }
    }
}
