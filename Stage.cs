﻿using System;
using System.IO;

namespace soukoban_ex
{
    public  abstract  class Stage
    {
        protected int stageWidth;
        protected string[] allStageChar;
        protected ObjectManager objectManager = new ObjectManager();

        public void startGame(String filepath){
            readMap(filepath);
            createObject();
            update();
        }

        private void readMap(String filePath){
            allStageChar = File.ReadAllLines(filePath);
			stageWidth = allStageChar[0].Length;
        }

        protected void CheckGoal(){
            
            if (!objectManager.hasGoal())
			{
				Console.WriteLine("ゲームクリア");
				Environment.Exit(0);
			}
        }

        protected abstract void createObject();
        protected abstract void update();

    }
}
