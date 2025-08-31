# AWS S3 File Listing Tool

## Description
This is a simple Python-based AWS S3 file listing tool. It retrieves and displays a list of files stored in a specified S3 bucket.

## Requirements
- Python 3.x
- AWS account and credentials configured (`aws configure`)
- boto3 library

## Installation
1. Clone this repository or extract the zip file.
2. Navigate to the project folder.
3. Install required dependencies:
   ```bash
   pip install boto3
   ```

## Running the Application
Run the script using:
```bash
python main.py
```
You will be prompted to enter:
- **S3 bucket name**

## Example
```
Enter the S3 bucket name: my-bucket
```
Output:
```
Files in bucket 'my-bucket':
 - example1.txt
 - example2.jpg
 - folder/example3.pdf
```

## Considerations
- Ensure your AWS credentials are configured (`aws configure`).
- The bucket must have appropriate permissions to allow access.
