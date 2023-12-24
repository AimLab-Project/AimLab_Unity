// File: MyPlugin.jslib

mergeInto(LibraryManager.library, {
  CallReactScore: function (score) {
    dispatchReactUnityEvent("CallReactScore", score);
  },CallReactMessage: function (message) {
    dispatchReactUnityEvent("CallReactMessage", Pointer_stringify(message));
  },
});