public class DyanamicGameCondition
{
    public enum gameCondition
    {
        NormalScene,
        MenueScene
    }

    private gameCondition currentScene = gameCondition.NormalScene;
    public void setCurrentScene(gameCondition scene){
        this.currentScene = scene;
    }

    public gameCondition getCurrentScene()
    {
        return currentScene;
    }

}
