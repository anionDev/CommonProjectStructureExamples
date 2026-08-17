package main

import (
	"fmt"
	"strings"
)

// GetGreeting returns the greeting for the given name.
//
// When the name is empty or contains only whitespace then the greeting is addressed to the world,
// because a greeting without an addressee is still a valid greeting and the caller should not have
// to handle a missing name itself.
func GetGreeting(name string) string {
	addressee := strings.TrimSpace(name)
	if addressee == "" {
		addressee = "world"
	}
	return fmt.Sprintf("Hello, %s!", addressee)
}
