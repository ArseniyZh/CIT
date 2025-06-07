package com.example.myapplication;

import android.content.Intent;
import android.os.Bundle;

import androidx.appcompat.app.AppCompatActivity;

public class MainActivity2 extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main2);

        findViewById(R.id.button).setOnClickListener(v -> {
            startActivity(new Intent(this, MainActivity.class));
        });

        findViewById(R.id.main).setOnTouchListener(new OnSwipe(this) {
            @Override
            public void onSwipeRight() {
                Intent switcherRight = new Intent(MainActivity2.this, MainActivity.class);
                startActivity(switcherRight);
            }

            @Override
            public void onSwipeLeft() {
                Intent switcherLeft = new Intent(MainActivity2.this, MainActivity.class);
                startActivity(switcherLeft);
            }

            @Override
            public void onSwipeTop() {
                Intent switcherTop = new Intent(MainActivity2.this, MainActivity.class);
                startActivity(switcherTop);
            }

            @Override
            public void onSwipeBottom() {
                Intent switcherBottom = new Intent(MainActivity2.this, MainActivity.class);
                startActivity(switcherBottom);
            }
        });
    }
}
