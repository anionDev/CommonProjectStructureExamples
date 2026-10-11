import 'package:flutter/material.dart';

import 'app_theme.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'FlutterCodeUnit',
      // The application's colors come from one place only (see lib/app_theme.dart): the light and the
      // dark palette. Material applies them to every widget through these two themes.
      theme: appLightTheme,
      darkTheme: appDarkTheme,
      home: const HelloWorldPage(),
    );
  }
}

class HelloWorldPage extends StatelessWidget {
  const HelloWorldPage({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text('FlutterCodeUnit')),
      body: const Center(
        child: Text('Hello, World!', style: TextStyle(fontSize: 24)),
      ),
    );
  }
}
