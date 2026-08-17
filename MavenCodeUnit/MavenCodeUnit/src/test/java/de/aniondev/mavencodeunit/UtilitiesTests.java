package de.aniondev.mavencodeunit;

import static org.junit.jupiter.api.Assertions.assertEquals;

import org.junit.jupiter.api.Test;

/** Contains the testcases for {@link Utilities}. */
final class UtilitiesTests {

  @Test
  void getGreetingShouldGreetTheGivenName() {
    assertEquals("Hello, Alice!", Utilities.getGreeting("Alice"));
  }

  @Test
  void getGreetingShouldIgnoreTheWhitespaceAroundTheGivenName() {
    assertEquals("Hello, Alice!", Utilities.getGreeting("  Alice  "));
  }

  @Test
  void getGreetingShouldGreetTheWorldWhenNoNameIsGiven() {
    assertEquals("Hello, world!", Utilities.getGreeting(null));
  }

  @Test
  void getGreetingShouldGreetTheWorldWhenTheGivenNameContainsOnlyWhitespace() {
    assertEquals("Hello, world!", Utilities.getGreeting("   "));
  }
}
