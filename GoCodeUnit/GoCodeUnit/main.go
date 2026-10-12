// Package main contains the commandline-application of this codeunit.
package main

import (
	"fmt"
	"os"
)

// main is the entry-point of this codeunit. It prints the greeting for the name which is given as
// first argument, or the greeting for the world when no argument is given.
func main() {
	name := ""
	if len(os.Args) > 1 {
		name = os.Args[1]
	}
	fmt.Println(GetGreeting(name))
}
