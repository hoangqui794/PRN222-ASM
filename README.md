# PRN222 - Assignment Project

## Git Workflow - Quy trình làm việc với Git

### 🌳 Cấu trúc nhánh (Branch Structure)

- **`main`**: Nhánh chính, chỉ chứa code đã hoàn thiện và ổn định
- **`dev`**: Nhánh phát triển, dùng để tích hợp code từ các nhánh feature
- **`feature/ten-chuc-nang`**: Nhánh cá nhân của từng thành viên

### 📋 Quy trình làm việc (Workflow)

#### 1. Tạo nhánh cá nhân
```bash
# Tạo nhánh mới từ dev
git checkout dev
git pull origin dev
git checkout -b feature/ten-chuc-nang
```

#### 2. Làm việc trên nhánh của mình
```bash
# Thêm và commit code
git add .
git commit -m "Mô tả công việc đã làm"

# Push lên nhánh cá nhân
git push origin feature/ten-chuc-nang
```

#### 3. Merge vào nhánh dev
```bash
# Cập nhật code mới nhất từ dev
git checkout dev
git pull origin dev

# Merge nhánh của mình vào dev
git merge feature/ten-chuc-nang

# Nếu có conflict, fix conflict rồi:
git add .
git commit -m "Fix conflicts"

# Push lên dev
git push origin dev
```

#### 4. Merge vào main (sau khi test kỹ trên dev)
```bash
# Chỉ merge vào main khi đã test kỹ và không còn lỗi
git checkout main
git pull origin main
git merge dev
git push origin main
```

### ⚠️ Lưu ý quan trọng

- **KHÔNG BAO GIỜ** push trực tiếp lên nhánh `main`
- Luôn làm việc trên nhánh cá nhân `feature/ten-chuc-nang`
- Merge vào `dev` trước để kiểm tra và fix lỗi
- Chỉ merge vào `main` khi code đã ổn định hoàn toàn
- Thường xuyên pull code mới nhất từ `dev` để tránh conflict lớn

### 🔄 Tránh conflict

```bash
# Trước khi bắt đầu làm việc mỗi ngày
git checkout dev
git pull origin dev
git checkout feature/ten-chuc-nang
git merge dev  # Cập nhật code mới nhất vào nhánh của mình
```

---

## Team Members
- Cao Hữu Trí Phèn
