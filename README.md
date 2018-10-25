# ID_Card_segmentation
Segmentation to get the fingerprints in an ID card

![alt text](https://github.com/habom2310/Finger-prints-form-ID-Card-using-segmentation/blob/master/result.PNG)

# Abstract
  Normally when we add a new user to a fingerprints authorized devices, the person needs to be in the place of enrolment. If we can extract the fingerprints information in an ID card or any document contains fingerprints, we can enroll new users into those devices without the present of the users. It will help to make the fingerprint enrolment much more convenient and faster.

# Method
- use morphologyEx, closing mode to get rid of small dots and also fill the fingerprint regions.
- Use histogram by both x and y axis to detect the regions of the fingerprints.
- Set reasonable thresholds to extract the fingerprints.

# Requirement
- Emgucv: install EmguCV using Nuget Packet Managerment in Visual Studio. 
  
# Implementation
- Download the project and re-build.
- In case of error with EmguCV references (github doesn't allow to upload files with more than 25MB, therefore some of dll files are missed), create new project and copy/paste all the codes in the Form1.cs and Form1.Designer.cs, all you need is in there.

# Result
- Fingerprints are successfully extracted from any scanned image.
- Automatically crop and rotate fingerprint images so you just need to save it and use.

