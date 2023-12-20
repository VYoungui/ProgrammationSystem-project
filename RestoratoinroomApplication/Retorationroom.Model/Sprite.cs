namespace ApplicationRestorationroom.Retorationroom.model
{
    public abstract class Sprite
    { 
        private string spriteImg; 
        private bool state;
        private int size;
        private Map x; 
        private Map y; 
        private Map map;
        
        public Sprite(string spriteImg, bool state, int size)
        {
            this.spriteImg = spriteImg;
            this.state = state;
            this.size = size;
        }
            
        public string SpriteImg
        {
            get => spriteImg;
            set => spriteImg = value;
        }
            
        public bool State
        {
            get => state;
            set => state = value;
        }
            
        public int Size
        {
            get => size;
            set => size = value;
        }
            
        public Map X
        {
            get => x;
            set => x = value;
        }
            
        public Map Y
        {
            get => y;
            set => y = value;
        }
            
        public Map Map
        {
            get => map;
            set => map = value;
        }
            
            
    }
                    
}