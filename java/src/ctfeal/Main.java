package ctfeal;

import java.io.IOException;
import java.nio.charset.Charset;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.HashMap;
import java.util.Map;

public class Main {
    public static void main(String[] args) throws IOException {
        String bible = Files.readAllLines(Paths.get("C:\\Users\\utente\\Desktop\\bible.txt"), Charset.defaultCharset()).get(0); //get the bible

        for (int y = 0; y < bible.length(); y++) {
            int spacing = y;
            for (int i = 0; i < spacing; i++) {
                int c = i;
                StringBuilder builder = new StringBuilder();
                while (c < bible.length()) {
                    builder.append(bible.charAt(c));
                    c += spacing;
                }
                String result = builder.toString();
                
                if (result.contains("EAL{")) {
                    System.out.println(result);
                }
            }
        }
    }
}
