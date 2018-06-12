<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <title>Search Bar</title>
    </head>
    <style>
        html {
            font-family: arial, sans-serif;
        }
        
        table {
            border-collapse: collapse;
        }
        
        td, th {
            border : 1px solid #dddddd;
            text-align: left;
            padding: 8px;
        }
        
        tr:nth-child(even) {
            background-color: #dddddd;
        }
    </style>
    <body>
        <h1>Search Bar</h1>
        <p>The search bar below works by executing the string as part of a SQL Query</p>
        <form action="" method="POST">
            Query:  <input type="text" name="query"><br><br>
            <input type="submit">
        </form>
        <?php
            if($_POST) {
                $query = $_POST['query'];
                class MyDB extends SQLite3 {
                    function __construct() {
                        $this->open('search.db');
                    }
                }
                $db = new MyDB();
                if(!$db) {
                    echo $db->lastErrorMsg();
                } else {
                    $sql = "SELECT * FROM search WHERE query LIKE '%" . $query . "%';";
                    $result = $db->query($sql);
                    echo "<br>";
                    echo "<h2>Results</h2>";
                    echo "<table><tr><th>Query</th><th>Content</th></tr>";
                    while($row = $result->fetchArray(SQLITE3_ASSOC) ) {
                        $res_query = str_replace("<","&lt;", $row['query']);
                        $res_query = str_replace(">","&gt;", $res_query);
                        echo "<tr><td>". $res_query . "</td>";
                        $res_content = str_replace("<","&lt;", $row['content']);
                        $res_content = str_replace(">","&gt;", $res_content);
                        echo "<td>" . $res_content . "</td></tr>";
                    }
                    echo "</table><br>";
                $db->close();
                }
            }
        ?>
    </body>
</html>
