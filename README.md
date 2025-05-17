# 🚗 Oman Driving School Registration System

## 🏫 Scenario

A driving school in Nizwa offers training sessions for different types of vehicle licenses:
- Light
- Heavy
- Motorcycle

Each student must register and be assigned to an instructor. Students can book lessons, and instructors provide feedback after each lesson.

### 🎯 System Requirements

The school director wants the system to:

- ✅ Register students and instructors.
- ✅ Schedule lessons (with date and time), ensuring no overlapping schedules.
- ✅ Track which students attended which lessons and with which instructors.
- ✅ Mark lessons as completed and store the instructor’s notes.
- ✅ Provide a way to view all completed lessons for a specific student.

---

## 🧠 Your Tasks

- [ ] Extract the necessary **entities** and define their **relationships**.
- [ ] Design an **ERD (Entity Relationship Diagram)** and **class structure** based on the requirements.
- [ ] Build a **console application** simulating this system using only **lists or arrays**.

---

## 💻 Sample Console Application Output

```plaintext
===========================================
    Nizwa Driving School System
===========================================
1. Register New Student
2. Register New Instructor
3. Book Driving Lesson
4. Record Lesson Completion & Instructor Feedback
5. View Student Lesson History
6. View All Scheduled Lessons
7. Exit
Select an option: 1

-- Register New Student --
Enter Student Name: Aisha Al Farsi
Enter Phone Number: 98765432
Enter License Type (Light / Heavy / Motorcycle): Light
✅ Student registered with ID: ST001
-------------------------------------------
Select an option: 2

-- Register New Instructor --
Enter Instructor Name: Khalid Al Riyami
Enter Phone Number: 93344556
Enter Specialization (Light / Heavy / Motorcycle): Light
✅ Instructor registered with ID: IN001
-------------------------------------------
Select an option: 3

-- Book Driving Lesson --
Enter Student ID: ST001
Enter Instructor ID: IN001
Enter Lesson Date (dd/mm/yyyy): 12/05/2025
Enter Time (HH:mm): 10:00
✅ Lesson scheduled successfully.
-------------------------------------------
Select an option: 4

-- Record Lesson Completion & Feedback --
Enter Student ID: ST001
Enter Lesson Date: 12/05/2025
Enter Notes: Student demonstrated good control. Needs more practice with parallel parking.
✅ Lesson marked as completed and feedback saved.
-------------------------------------------
Select an option: 5

-- View Student Lesson History --
Enter Student ID: ST001
📘 Lesson History for Aisha Al Farsi:
[1] Date: 12/05/2025 | Time: 10:00 | Instructor: Khalid Al Riyami
Feedback: Student demonstrated good control. Needs more practice with parallel parking.
-------------------------------------------
Select an option: 6

-- View All Scheduled Lessons --
[1] ST001 | Aisha Al Farsi | IN001 | Khalid Al Riyami | 12/05/2025 at 10:00
-------------------------------------------
Select an option: 7

Thank you for using Nizwa Driving School System. Goodbye!
