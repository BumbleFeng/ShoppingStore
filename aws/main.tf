provider "aws" {
  region     = "us-east-1"
}

resource "aws_security_group" "tenable" {
  name = "tenable-scanner"
  description = "Web Security Group"
        
  ingress {
    from_port = 22
    to_port = 22
    protocol = "tcp"
    cidr_blocks = ["0.0.0.0/0"]
  }

  ingress {
    from_port = 3389
    to_port = 3389
    protocol = "tcp"
    cidr_blocks = ["0.0.0.0/0"]
  }
		
		
  ingress {
    from_port = 80
    to_port = 80
    protocol = "tcp"
    cidr_blocks = ["0.0.0.0/0"]
  }
		
  ingress {
    from_port = 443
    to_port = 443
    protocol = "tcp"
    cidr_blocks = ["0.0.0.0/0"]
  }

  egress {
    from_port = 0
    to_port = 0
    protocol = "-1"
    cidr_blocks = ["0.0.0.0/0"]
  }
}

resource "aws_instance" "vault-example" {
  ami           = "ami-064536628aee854d9"
  instance_type = "t2.micro"
  security_groups = ["${aws_security_group.tenable.name}"]
  key_name = "ec2"
	
  tags {
    Name = "myweb"
  }
  
  provisioner "local-exec" {
    command = "echo ${aws_instance.vault-example.public_ip} > ip_address.txt"
  }
}