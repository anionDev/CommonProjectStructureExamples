package de.aniondev.mavencodeunit;

/** Contains the functions of this codeunit which are not bound to the commandline-interface. */
public final class Utilities {

  private Utilities() {
    // This class only contains static functions, so it must not be instantiated.
  }

  /**
   * Returns the greeting for the given name.
   *
   * @param name the name of the one to greet. When it is null or contains only whitespace then the
   *     greeting is addressed to the world, because a greeting without an addressee is still a
   *     valid greeting and the caller should not have to handle a missing name itself.
   * @return the greeting
   */
  public static String getGreeting(final String name) {
    final String addressee;
    if (name == null || name.isBlank()) {
      addressee = "world";
    } else {
      addressee = name.strip();
    }
    return "Hello, " + addressee + "!";
  }
}
