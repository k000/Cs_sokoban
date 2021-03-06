﻿using System;
namespace soukoban_ex
{
    public abstract class Factory
    {
        public GameObject create(char type){
            GameObject gameobject = createGameObject(type);
            return gameobject;
        }
        protected abstract GameObject createGameObject(char type);
    }
}
