<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
</head>
<body>
    <h1>Coffee Disease API</h1>
    <p>This API provides functionality for predicting coffee diseases based on input images.</p>
    <h2>Endpoints</h2>
    <ul>
        <li><strong>POST /api/Image/predict</strong>: Predicts coffee disease based on input image.</li>
    </ul>
    <h3>Request</h3>
    <p>The request should be a multipart/form-data POST request containing an image file.</p>
    <h3>Response</h3>
    <p>The response contains a JSON object with two properties:</p>
    <ul>
        <li><strong>ClassName</strong>: The predicted class name of the coffee disease.</li>
        <li><strong>Score</strong>: The confidence score of the prediction (rounded to two decimal places).</li>
    </ul>
   
</body>
</html>
