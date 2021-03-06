﻿
namespace soukoban_ex
{
    public class NomalStage : Stage
    {
       
        protected override void createObject(){
            Factory factory = new GameObjectFactory();
            foreach(var lines in allStageChar){
                foreach(var ch in lines)
                    objectManager.addObject(factory.create(ch));
             }
        }

        protected override void update(){
            
            InputManager inputManager = new InputManager();
            ActionManager actionManager = new ActionManager(objectManager);
            objectManager.printObject(stageWidth);

            while(true){

                var player = objectManager.getPlayerObject();
                var direction = inputManager.getInputKey(stageWidth);
                var nextObj = objectManager.getNextObject(direction);


                if (nextObj.objectType == GameObject.ObjectType.WALL){
					objectManager.printObject(stageWidth);
					continue;
                }

                if(nextObj.objectType == GameObject.ObjectType.NIMOTUONGOAL){
                    objectManager.printObject(stageWidth);
                    continue;
                }

                if(nextObj.objectType == GameObject.ObjectType.GOAL){
                    actionManager.hitGoal(direction);
                    objectManager.printObject(stageWidth);
                    continue;
                }

                if(nextObj.objectType == GameObject.ObjectType.NIMOTU){
                    actionManager.hitNimotu(direction);
                    objectManager.printObject(stageWidth);
					
                    CheckGoal();
                    continue;
                }

                if(player.type == CharManager.getPlayerChar())
                    player.changeType(CharManager.getFloorChar(), GameObject.ObjectType.FLOOR);
                else
                    player.changeType(CharManager.getGoalChar(), GameObject.ObjectType.GOAL);
                
                nextObj.changeType(CharManager.getPlayerChar(), GameObject.ObjectType.PLAYER);
                objectManager.printObject(stageWidth);

            }
        }

    }
}
