namespace PasswordHasher {
    public interface IInputHandler {
        string Prompt(string msg);
        bool PromptConfirm(string msg);
        string PromptPassword();
    }
}