import 'dart:async';
import 'dart:io';

import 'package:flutter/services.dart';
import 'package:flutter_test/flutter_test.dart';

/// Runs before every test-file of this package.
///
/// Without this, `flutter test` renders text and icons with a placeholder test-font (solid boxes instead of glyphs)
/// instead of the real "Roboto" the app bundles (see pubspec.yaml's `flutter.fonts` and `lib/app_theme.dart`'s
/// `ThemeData.fontFamily`) and the real "MaterialIcons" font every `Icons.*` uses. That makes the visual output of
/// a test depend on the host instead of being reproducible on the Windows host and inside the Linux build-container
/// alike, so both real fonts are loaded here once for the whole test-run.
///
/// The Roboto font-file is read directly via `dart:io` instead of through `rootBundle`: the font is declared with a
/// path that escapes this package's own folder (`../Other/Resources/Fonts/...`, see pubspec.yaml), and while that is
/// bundled correctly for a real build, `flutter test`'s test-asset-bundle does not actually contain the font's bytes
/// under that key.
///
/// The MaterialIcons font-file is not part of this repository at all (unlike Roboto): it ships inside the Flutter
/// SDK itself (`$FLUTTER_ROOT/bin/cache/artifacts/material_fonts/MaterialIcons-Regular.otf`, the exact file
/// `flutter build` already bundles into every real app automatically because of pubspec.yaml's
/// `uses-material-design: true` - `flutter test` just never loads it), so it is read from there via the
/// `FLUTTER_ROOT` environment variable `flutter test` itself sets for the process it spawns.
Future<void> testExecutable(FutureOr<void> Function() testMain) async {
  TestWidgetsFlutterBinding.ensureInitialized();
  // `flutter test` always runs with the current directory set to this package, so the font-folder is reached the
  // same way the app's pubspec.yaml reaches it.
  await _loadFont('Roboto', '../Other/Resources/Fonts/Roboto-Regular.ttf');
  await _loadFont('Roboto', '../Other/Resources/Fonts/Roboto-Bold.ttf');
  final String? flutterRoot = Platform.environment['FLUTTER_ROOT'];
  if (flutterRoot != null) {
    await _loadFont('MaterialIcons', '$flutterRoot/bin/cache/artifacts/material_fonts/MaterialIcons-Regular.otf');
  }
  return testMain();
}

Future<void> _loadFont(String family, String path) async {
  final Uint8List bytes = File(path).readAsBytesSync();
  final ByteData fontData = bytes.buffer.asByteData();
  final FontLoader fontLoader = FontLoader(family)..addFont(Future.value(fontData));
  await fontLoader.load();
}
