import boto3

def list_files_in_s3(bucket_name):
    try:
        s3 = boto3.client('s3')

        # Retrieve file listing
        response = s3.list_objects_v2(Bucket=bucket_name)

        if 'Contents' in response:
            print(f"Files in bucket '{bucket_name}':")
            for obj in response['Contents']:
                print(f" - {obj['Key']}")
        else:
            print(f"No files found in bucket '{bucket_name}'.")

    except Exception as e:
        print(f"An error occurred: {e}")

if __name__ == "__main__":
    bucket_name = input("Enter the S3 bucket name: ")
    list_files_in_s3(bucket_name)
