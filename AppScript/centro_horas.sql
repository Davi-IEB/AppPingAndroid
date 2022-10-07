--
--CREATE TABLE tb_centro_de_trabalho_disponibilidade_970
--(
--
--cod_empresa CHAR(2),
--cod_equip CHAR(15),
--horas_disponiveis DECIMAL(10,3)
--
--)


SELECT
CT.cod_empresa,
CT.den_reduz,
CT.setor,
CT.cod_cent_trab,
CT.den_cent_trab,
CT.cod_equip,
CAST(sum((ORD.qtd_planej-ORD.qtd_boas)/MP.qtd_pecas_ciclo) AS INTEGER) AS horas_necessarias
FROM tb_centro_de_trabalho_970 CT
LEFT JOIN tb_programa_maquina_970 PM ON PM.cod_empresa=CT.cod_empresa AND PM.cod_equip=CT.cod_equip
LEFT JOIN ordens ORD ON ORD.cod_empresa=PM.cod_empresa AND ORD.num_ordem=PM.num_ordem
LEFT JOIN man_processo_item MP ON MP.empresa=ORD.cod_empresa AND MP.item=ORD.cod_item
WHERE ORD.ies_situa IN('2','3','4')
AND MP.validade_final IS NULL
AND MP.operacao NOT IN('042','199')
AND CT.cod_empresa='01'
GROUP BY 1,2,3,4,5,6
ORDER BY CT.cod_empresa, CT.setor


