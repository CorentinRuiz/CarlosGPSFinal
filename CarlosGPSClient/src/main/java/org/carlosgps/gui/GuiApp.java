package org.carlosgps.gui;

import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.image.Image;
import javafx.stage.Stage;
import javafx.stage.StageStyle;

import java.util.Objects;

public class GuiApp extends Application {
    double x,y = 0;

    @Override
    public void start(Stage stage) throws Exception {
        Parent root = FXMLLoader.load(Objects.requireNonNull(GuiApp.class.getClassLoader().getResource("main-view.fxml")));

        Scene scene = new Scene(root, 1200, 800);
        stage.getIcons().add(new Image(getClass().getClassLoader().getResource("icons/carte32.png").toString()));
        stage.setTitle("Carlos GPS");
        stage.initStyle(StageStyle.UNDECORATED);

        root.setOnMousePressed(e ->{
            x = e.getSceneX();
            y = e.getSceneY();
        });

        root.setOnMouseDragged(e ->{
            stage.setX(e.getScreenX() - x);
            stage.setY(e.getScreenY() - y);
        });

        stage.setScene(scene);
        stage.show();
    }

    public static void main() {
        launch();
    }
}
