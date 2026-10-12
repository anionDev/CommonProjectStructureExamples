package main

import "testing"

func TestGetGreetingShouldGreetTheGivenName(t *testing.T) {
	assertGreetingIs(t, "Hello, Alice!", GetGreeting("Alice"))
}

func TestGetGreetingShouldIgnoreTheWhitespaceAroundTheGivenName(t *testing.T) {
	assertGreetingIs(t, "Hello, Alice!", GetGreeting("  Alice  "))
}

func TestGetGreetingShouldGreetTheWorldWhenNoNameIsGiven(t *testing.T) {
	assertGreetingIs(t, "Hello, world!", GetGreeting(""))
}

func TestGetGreetingShouldGreetTheWorldWhenTheGivenNameContainsOnlyWhitespace(t *testing.T) {
	assertGreetingIs(t, "Hello, world!", GetGreeting("   "))
}

func assertGreetingIs(t *testing.T, expected string, actual string) {
	t.Helper()
	if actual != expected {
		t.Errorf("Expected %q but got %q.", expected, actual)
	}
}
