namespace EducationPortal.Data.Entities
{
    public abstract class Course<T>
        where T : Material
    {
        public Course()
        {

        }

        public Course(string name, T material, string description, int score)
        {
            Name = name;
            Description = description;
            Score = score;
            Material = material;
        }

        public string Name { get; }
        public string Description { get; set; }
        public T Material { get; set; }
        public int Score { get; set; }

        public Material GetMaterial()
        {
            return Material;
        }
    }
}
