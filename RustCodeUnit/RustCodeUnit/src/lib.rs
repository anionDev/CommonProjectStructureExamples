//! Contains the functions of this codeunit which are not bound to the commandline-interface.

/// Returns the greeting for the given name.
///
/// When the name is empty or contains only whitespace then the greeting is addressed to the world,
/// because a greeting without an addressee is still a valid greeting and the caller should not have
/// to handle a missing name itself.
pub fn get_greeting(name: &str) -> String {
    let addressee = name.trim();
    if addressee.is_empty() {
        "Hello, world!".to_string()
    } else {
        format!("Hello, {addressee}!")
    }
}

#[cfg(test)]
mod tests {
    use super::get_greeting;

    #[test]
    fn get_greeting_should_greet_the_given_name() {
        assert_eq!("Hello, Alice!", get_greeting("Alice"));
    }

    #[test]
    fn get_greeting_should_ignore_the_whitespace_around_the_given_name() {
        assert_eq!("Hello, Alice!", get_greeting("  Alice  "));
    }

    #[test]
    fn get_greeting_should_greet_the_world_when_no_name_is_given() {
        assert_eq!("Hello, world!", get_greeting(""));
    }

    #[test]
    fn get_greeting_should_greet_the_world_when_the_given_name_contains_only_whitespace() {
        assert_eq!("Hello, world!", get_greeting("   "));
    }
}
