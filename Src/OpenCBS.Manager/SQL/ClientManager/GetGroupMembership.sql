SELECT v.id Id,
    v.name Name,
    'NSG' Type,
    v.establishment_date EstablishedAt,
    vp.joined_date JoinedAt,
    vp.left_date LeftAt
FROM dbo.VillagesPersons vp
INNER JOIN dbo.Villages v ON v.id = vp.village_id
WHERE vp.person_id = @PersonId

UNION ALL

SELECT g.id,
    g.name,
    'SG',
    g.establishment_date,
    pgb.joined_date,
    pgb.left_date
FROM dbo.PersonGroupBelonging pgb
INNER JOIN dbo.Groups g ON g.id = pgb.group_id
WHERE pgb.person_id = @PersonId
