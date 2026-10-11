import 'package:flutter/material.dart';

/// The colors one theme-mode (light or dark) of the application is built from.
///
/// This class together with its two instances [lightPalette] and [darkPalette] is the single source
/// of truth for the application's colors. To restyle the application, change the color-values of
/// those two palettes - nothing else, and nowhere else: [appLightTheme]/[appDarkTheme] turn a palette
/// into the [ThemeData] that Material applies to every widget, so every color on screen traces back
/// to exactly one field here. A widget therefore never names a color of its own; it reads the role it
/// needs from `Theme.of(context).colorScheme`.
///
/// The fields are named after the Material-3 color-roles they feed, so the mapping in [_buildTheme] is
/// one-to-one and there is no hidden colour. The few intermediate surface-tones Material also knows
/// (`surfaceContainerLow`/`-High`) are interpolated between [surface], [surfaceContainer] and
/// [surfaceContainerHighest] so a palette only has to state the three tones the application actually
/// distinguishes.
@immutable
class AppColorPalette {
  /// The page-background (the scaffold). [onSurface] is the text and icons shown on it and on every
  /// surface below.
  final Color surface;

  /// Raised surfaces that sit on the background - cards, dialogs, menus, the scrolled-under app-bar -
  /// in two steps of increasing emphasis ([surfaceContainer] < [surfaceContainerHighest]) so adjacent
  /// surfaces can be told apart.
  final Color surfaceContainer;
  final Color surfaceContainerHighest;

  /// Text and icons on any surface. [onSurfaceVariant] is the quieter variant for text of lower
  /// emphasis (hints, captions, secondary labels).
  final Color onSurface;
  final Color onSurfaceVariant;

  /// The accent that carries the brand: filled buttons, selection, focus, active controls.
  /// [onPrimary] is the text and icons shown on top of [primary]. [primaryContainer] /
  /// [onPrimaryContainer] are the quieter, tinted variant used for less prominent emphasis.
  final Color primary;
  final Color onPrimary;
  final Color primaryContainer;
  final Color onPrimaryContainer;

  /// A supporting accent for secondary emphasis. [onSecondary] is the text/icons shown on it.
  final Color secondary;
  final Color onSecondary;

  /// Hairlines and borders ([outline]) and their quieter variant ([outlineVariant], e.g. dividers).
  final Color outline;
  final Color outlineVariant;

  /// The error state and the text/icons shown on it.
  final Color error;
  final Color onError;

  const AppColorPalette({
    required this.surface,
    required this.surfaceContainer,
    required this.surfaceContainerHighest,
    required this.onSurface,
    required this.onSurfaceVariant,
    required this.primary,
    required this.onPrimary,
    required this.primaryContainer,
    required this.onPrimaryContainer,
    required this.secondary,
    required this.onSecondary,
    required this.outline,
    required this.outlineVariant,
    required this.error,
    required this.onError,
  });
}

/// The light theme: a very light, cool-white background with text and accents in a deep, glossy
/// sapphire-blue.
const AppColorPalette lightPalette = AppColorPalette(
  surface: Color(0xFFF6F8FC),
  surfaceContainer: Color(0xFFEDF1F9),
  surfaceContainerHighest: Color(0xFFE1E8F4),
  onSurface: Color(0xFF0D2A66),
  onSurfaceVariant: Color(0xFF45527A),
  primary: Color(0xFF0D2A66),
  onPrimary: Color(0xFFFFFFFF),
  primaryContainer: Color(0xFFDBE3F7),
  onPrimaryContainer: Color(0xFF0A2050),
  secondary: Color(0xFF3A5490),
  onSecondary: Color(0xFFFFFFFF),
  outline: Color(0xFFBBC5DA),
  outlineVariant: Color(0xFFD6DEEC),
  error: Color(0xFFBA1A1A),
  onError: Color(0xFFFFFFFF),
);

/// The dark theme: a deep marine-blue background with text and accents in a glossy, metallic gold.
const AppColorPalette darkPalette = AppColorPalette(
  surface: Color(0xFF0A1A3C),
  surfaceContainer: Color(0xFF122650),
  surfaceContainerHighest: Color(0xFF1B3362),
  onSurface: Color(0xFFD4AF37),
  onSurfaceVariant: Color(0xFFCBB884),
  primary: Color(0xFFD4AF37),
  onPrimary: Color(0xFF10224A),
  primaryContainer: Color(0xFF3C3310),
  onPrimaryContainer: Color(0xFFF3DB9C),
  secondary: Color(0xFFC9B06A),
  onSecondary: Color(0xFF241E07),
  outline: Color(0xFF44588A),
  outlineVariant: Color(0xFF2A3C66),
  error: Color(0xFFFFB4AB),
  onError: Color(0xFF690005),
);

/// The [ThemeData] Material applies when the light theme is active. Built once from [lightPalette].
final ThemeData appLightTheme = _buildTheme(lightPalette, Brightness.light);

/// The [ThemeData] Material applies when the dark theme is active. Built once from [darkPalette].
final ThemeData appDarkTheme = _buildTheme(darkPalette, Brightness.dark);

ThemeData _buildTheme(AppColorPalette palette, Brightness brightness) {
  final ColorScheme colorScheme = ColorScheme(
    brightness: brightness,
    primary: palette.primary,
    onPrimary: palette.onPrimary,
    primaryContainer: palette.primaryContainer,
    onPrimaryContainer: palette.onPrimaryContainer,
    secondary: palette.secondary,
    onSecondary: palette.onSecondary,
    secondaryContainer: palette.primaryContainer,
    onSecondaryContainer: palette.onPrimaryContainer,
    tertiary: palette.secondary,
    onTertiary: palette.onSecondary,
    error: palette.error,
    onError: palette.onError,
    surface: palette.surface,
    onSurface: palette.onSurface,
    onSurfaceVariant: palette.onSurfaceVariant,
    surfaceContainerLowest: palette.surface,
    surfaceContainerLow: Color.lerp(palette.surface, palette.surfaceContainer, 0.5)!,
    surfaceContainer: palette.surfaceContainer,
    surfaceContainerHigh: Color.lerp(palette.surfaceContainer, palette.surfaceContainerHighest, 0.5)!,
    surfaceContainerHighest: palette.surfaceContainerHighest,
    outline: palette.outline,
    outlineVariant: palette.outlineVariant,
  );
  return ThemeData(
    useMaterial3: true,
    // The app bundles "Roboto" (see pubspec.yaml's flutter.fonts) and names it here, so every text renders with
    // that font instead of a machine-dependent default - the same pixels on the Windows host and inside the Linux
    // build-container, which test/flutter_test_config.dart relies on by loading the very same files.
    fontFamily: 'Roboto',
    colorScheme: colorScheme,
    scaffoldBackgroundColor: colorScheme.surface,
  );
}
