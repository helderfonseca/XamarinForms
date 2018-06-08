<?php
use \Psr\Http\Message\ServerRequestInterface as Request;
use \Psr\Http\Message\ResponseInterface as Response;

$app = new \Slim\App;


// Post Login 
$app->post('/v1/login', function(Request $request, Response $response){

    $input = $request->getParsedBody();
    //$pass = md5($input['password']);
    $sql = "SELECT username, password FROM users WHERE username= :username";
   
    try{

        //Get DB Object
        $db = new DB();
        //Connect
        $db = $db->Connect();
        $sth = $db->prepare($sql);
        $sth->bindParam("username", $input['username']);
        //$sth->bindParam("password", $input['password']);
        $sth->execute();
        $user = $sth->fetch(PDO::FETCH_OBJ);
        $db = null;
    
        // verify username.
        if(!$user) {
            return $this->response->withJson(['error' => true, 'message' => 'User not found.'], 204);  
        }
        // verify password.
        if (!password_verify($input['password'], $user->password)) {
            return $this->response->withJson(['error' => true, 'message' => 'Password incorreto!'], 404);  
        }

        //echo json_encode($user->user_password);
        return $this->response->withJson($user);

    }catch(PDOException $ex){
        //echo '{"error": {"text": '.$ex->getMessage().'}';
        return $this->response->withJson(['status' => "Failed", 'message' => "Invalid"], 400);
    }

});

// Get all users

$app->get('/v1/users', function(Request $request, Response $response){

    $sql = "SELECT * login FROM users";

    try{
        //Get DB Object
        $db = new DB();
        //Connect
        $db = $db->Connect();

        $stmt = $db->query($sql);
        $users = $stmt->fetchAll(PDO::FETCH_OBJ);
        $db = null;
        return $this->response->withJson($users);
    }catch(PDOException $ex){
        echo '{"error": {"text": '.$ex->getMessage().'}';
    }

});

// Get Logged User

$app->get('/v1/getPersonByUserName/{username}', function(Request $request, Response $response){

    $username = $request->getAttribute('username');
    $sql = "SELECT nome, email, dt_nasc FROM pessoa WHERE username LIKE '$username' LIMIT 1";

    try{
        //Get DB Object
        $db = new DB();
        //Connect
        $db = $db->Connect();

        $stmt = $db->query($sql);
        //$sth->bindParam(":username", $args['username']);
        //$stmt->execute();
        $userl = $stmt->fetch(PDO::FETCH_OBJ);
        $db = null;

        return $this->response->withJson($userl);
    }catch(PDOException $ex){
        echo '{"error": {"text": '.$ex->getMessage().'}';
    }
});