//! Contains the entry-point of this codeunit.

use rust_code_unit::get_greeting;

/// The entry-point of this codeunit. It prints the greeting for the name which is given as first
/// argument, or the greeting for the world when no argument is given.
fn main() {
    let name = std::env::args().nth(1).unwrap_or_default();
    println!("{}", get_greeting(&name));
}
