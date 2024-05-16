## Iaac with terraform

[Terraform Registry SAP BTP](https://registry.terraform.io/providers/SAP/btp/latest/docs)

The Terraform provider for SAP BTP enables you to automate the provisioning, management, and configuration of resources on SAP Business Technology Platform.

### Example Usage

```terraform
terraform {
  required_providers {
    btp = {
      source  = "SAP/btp"
      version = "1.0.0"
    }
  }
}

# Configure the BTP Provider
provider "btp" {
  globalaccount = "e6a55f07trial-ga"
}

resource "btp_subaccount" "my_project" {
  name      = "My Project"
  subdomain = "my-project-cadiaz"
  region    = "us10"
}

resource "btp_subaccount_entitlement" "alert_notification_service" {
  subaccount_id = btp_subaccount.my_project.id
  service_name  = "alert-notification"
  plan_name     = "standard"
}

resource "btp_subaccount_environment_instance" "cloudfoundry" {
  subaccount_id    = btp_subaccount.my_project.id
  name             = "my-cf-environment"
  environment_type = "cloudfoundry"
  service_name     = "cloudfoundry"
  plan_name        = "trial"
  parameters = jsonencode({
    instance_name = "e6a55f07trial_my-project-cadiaz"
  })
}
```

You need to pass credentials to the provider to authenticate and interact with your BTP environments. Please set the environment variables `BTP_USERNAME` and `BTP_PASSWORD`

```bash
export BTP_USERNAME=<your_username>
export BTP_PASSWORD=<your_password>
```

Foy using

```bash
terraform init
terraform apply
terraform destroy
```

links

- [Get Started with the Terraform Provider for BTP | SAP Tutorials](https://developers.sap.com/tutorials/btp-terraform-get-started.html)

- [Automating SAP BTP setup with Terraform](https://community.sap.com/t5/technology-blogs-by-members/automating-sap-btp-setup-with-terraform-a-workaround-for-global-account/ba-p/13552824)

### Obtain ids

```bash
btp list accounts/environment-instance --subaccount 0de7e779-0493-46ff-b920-2ee9e9ee5e59
```

link

[btp CLI Command Reference](https://help.sap.com/docs/btp/sap-business-technology-platform/working-with-environments-using-btp-cli)

and only view the terraform.tfstate file
