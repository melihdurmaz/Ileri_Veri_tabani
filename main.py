import pandas as pd
import pyodbc
from sklearn.model_selection import train_test_split
from sklearn.preprocessing import StandardScaler
from sklearn.tree import DecisionTreeClassifier


SERVER = r'(localdb)\MSSQLLocalDB'
DATABASE = r'İleriVeriTabani'
USERNAME = r''
PASSWORD = r''

connection_string = f'DRIVER={{ODBC Driver 17 for SQL Server}};SERVER={SERVER};DATABASE={DATABASE};UID={USERNAME};PWD={PASSWORD}'
conn = pyodbc.connect(connection_string)
cursor = conn.cursor()

file_path = r'C:\Users\ADMIN\OneDrive\Masaüstü\12\pythonProject\file\2022-2023 Football Player Stats.csv'
df_csv = pd.read_csv(file_path, encoding='ISO-8859-1', delimiter=';')

for index, row in df_csv.iterrows():

    row = row.where(pd.notnull(row), None)

    query = """
        INSERT INTO Players(PlayerName, PlayerAge, PlayerPosition, PlayerSquad, PlayerMinutesPlayed, PlayerTouches, PlayerTackles)
        VALUES (?, ?, ?, ?, ?, ?, ?)
    """
    data = [
        row['Player'], row['Age'], row['Pos'], row['Squad'], row['Min'], row['Touches'], row['TklW']
    ]
    #cursor.execute(query, data)
#cursor.commit()

cursor.execute("SELECT PlayerName FROM Players")
player_names = [row[0] for row in cursor.fetchall()]

cursor.execute("SELECT PlayerAge FROM Players")
player_age = [row[0] if row[0] is not None else None for row in cursor.fetchall()]

cursor.execute("SELECT PlayerTouches FROM Players")
player_touches = [row[0] for row in cursor.fetchall()]

cursor.execute("SELECT PlayerTackles FROM Players")
player_tackles = [row[0] for row in cursor.fetchall()]


df_players = pd.DataFrame({
    'PlayerName': player_names,
    'PlayerAge': player_age,
    'PlayerTouches': player_touches,
    'PlayerMinutesPlayed': player_touches,
    'PlayerTackles': player_tackles
})


# Verileri temizleme ve dönüştürme
df_players = df_players.dropna()
df_players['PlayerAge'] = df_players['PlayerAge'].astype(int)
df_players['PlayerTouches'] = df_players['PlayerTouches'].astype(int)
df_players['PlayerMinutesPlayed'] = df_players['PlayerMinutesPlayed'].astype(int)
df_players['PlayerTackles'] = df_players['PlayerTackles'].astype(int)

# Hedef değişkeni (sakatlanma riski) oluşturma
age_threshold = df_players['PlayerAge'].mean()
touches_threshold = 50
df_players['InjuryRisk'] = ((df_players['PlayerAge'] > age_threshold) & (df_players['PlayerTouches'] >= touches_threshold)).astype(int)

# Özellikler ve hedef değişken
X = df_players[['PlayerAge', 'PlayerMinutesPlayed', 'PlayerTouches', 'PlayerTackles']]
y = df_players['InjuryRisk']

# Veriyi eğitim ve test setlerine ayırma
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42)

# Veriyi ölçeklendirme
scaler = StandardScaler()
X_train = scaler.fit_transform(X_train)
X_test = scaler.transform(X_test)

# Decision Tree model oluşturma ve eğitme
dtc = DecisionTreeClassifier(random_state=42)
dtc.fit(X_train, y_train)



cursor.execute("SELECT TOP 1 * FROM Players ORDER BY PlayerID DESC")
new_case = cursor.fetchone()
print(new_case)
new_case_data = [new_case.PlayerAge, new_case.PlayerMinutesPlayed, new_case.PlayerTouches, new_case.PlayerTackles]
prediction = dtc.predict([new_case_data])
print(f"Yeni vakanın tahmini sonucu: {prediction[0]}")

