When performing a task, you must use the capabilities of Selenium WebDriver, a unit test framework (for example JUnit) and the Page Object concept.

Automate the following script:
1. Open https://cloud.google.com/products/calculator/?hl=en
2. Click on "Add to estimate" button.
3. Select "Compute Engine".
4. Fill out the form with the following data:
* Number of instances: 4
* Operating System / Software: Free: Debian, CentOS, CoreOS, Ubuntu or BYOL (Bring Your Own License)
* Provisioning model: Regular
* Machine Family: General purpose 
* Series: N1 
* Machine type: n1-standard-8 (vCPUs: 8, RAM: 30 GB)
* Select “Add GPUs“
* GPU type: NVIDIA V100
* Number of GPUs: 1
* Local SSD: 2x375 Gb
* Region: Netherlands (europe-west4)
Other options leave in the default state.
5. Click "Share" to see Total estimated cost
6. Click "Open estimate summary" to see Cost Estimate Summary, will be opened in separate tab browser.
7. Verify that the 'Cost Estimate Summary' matches with filled values in Step 4.
