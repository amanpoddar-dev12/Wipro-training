# AWS S3 File Downloader

## Description
This is a simple Python-based AWS S3 file downloader. It allows users to download files from an S3 bucket by providing the bucket name and file key.

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
- **File key (name in the bucket)**
- **Local download path**

## Example
```
Enter the S3 bucket name: my-bucket
Enter the file key (file name in bucket): example.txt
Enter the local path to save the file: ./example.txt
```
Output:
```
File 'example.txt' found in bucket 'my-bucket'. Downloading...
File downloaded successfully to ./example.txt
```

## Considerations
- Ensure your AWS credentials are configured (`aws configure`).
- The bucket must have appropriate permissions to allow access.
