package de.aniondev.mavencodeunit;

/** Contains the entry-point of this codeunit. */
public final class Program {

  private Program() {
    // This class only contains the entry-point, so it must not be instantiated.
  }

  /**
   * The entry-point of this codeunit. It prints the greeting for the name which is given as first
   * argument, or the greeting for the world when no argument is given.
   *
   * @param args the commandline-arguments
   */
  public static void main(final String[] args) {
    final String name = args.length == 0 ? null : args[0];
    System.out.println(Utilities.getGreeting(name));
  }
}
