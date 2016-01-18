public sealed class Singleton{
	private Singleton(){ }
	public static Singleton Instance{
		get {
			if(instance == null){
				lock(syncLock){
					if(instance == null){
						instance = new Singleton();
					}
				}
			}
			return instance;
		}
	}
	private static volatile Singleton instance;
	private static object syncLock = new object();
}