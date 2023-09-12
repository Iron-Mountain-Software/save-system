using System;
using UnityEngine;

namespace IronMountain.SaveSystem
{
    [Serializable]
    public struct SavedTexture2D
    {
        public event Action OnTexture2DChanged;
            
        [SerializeField] private string directory;
        [SerializeField] private string file;
        [SerializeField] private Texture2D texture2D;

        public string Directory
        {
            get => directory;
            set => directory = value;
        }
        
        public string File
        {
            get => file;
            set => file = value;
        }

        public Texture2D Texture2D
        {
            get
            {
                Load();
                return texture2D;
            }
            set
            {
                texture2D = value;
                Save();
                OnTexture2DChanged?.Invoke();
            }
        }

        public SavedTexture2D Load()
        {
            Texture2D savedTexture2D = SaveSystem.LoadTexture(directory, file);
            if (savedTexture2D != null) texture2D = savedTexture2D;
            return this;
        }

        public SavedTexture2D Save()
        {
            if (texture2D) SaveSystem.SaveTexture(directory, file, texture2D);
            else SaveSystem.DeleteFile(directory, file);
            return this;
        }
        
        public void Delete()
        {
            SaveSystem.DeleteFile(directory, file);
        }
        
        public bool Saved => SaveSystem.FileExists(directory, file);

        public Sprite CreateSprite(string name = "Saved Texture2D")
        {
            if (!texture2D) return null;
            Rect rect = new Rect(0, 0, texture2D.width, texture2D.height);
            Vector2 pivot = new Vector2(.5f, .5f);
            Sprite sprite = Sprite.Create(texture2D, rect, pivot);
            sprite.name = name;
            return sprite;
        }

        public SavedTexture2D(string directory, string file, Texture2D defaultTexture2D, Action onTexture2DChanged)
        {
            this.directory = directory;
            this.file = file;
            texture2D = SaveSystem.LoadTexture(this.directory, this.file) ?? defaultTexture2D;
            OnTexture2DChanged = onTexture2DChanged;
        }
    }
}
